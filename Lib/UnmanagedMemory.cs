using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace GCore.NativeInterop
{
    public class UnmanagedMemory : IDisposable
    {
        public IntPtr Ptr { get; protected set; } = IntPtr.Zero;
        public int Size { get; protected set; } = 0;

        protected void Alloc(int size)
        {
            if (size > 0)
            {
                Ptr = Marshal.AllocHGlobal(size);
                Size = size;
            }
        }

        protected UnmanagedMemory() { }

        public UnmanagedMemory(IntPtr ptr)
        {
            Ptr = ptr;
        }

        public UnmanagedMemory(int size)
        {
            Alloc(size);
        }

        public UnmanagedMemory(Type dataType, int count = 1)
        {
            Alloc(Marshal.SizeOf(dataType) * count);
        }

        ~UnmanagedMemory()
        {
            Dispose();
        }

        public void Dispose()
        {
            if (Ptr != IntPtr.Zero)
                Marshal.FreeHGlobal(Ptr);
            Ptr = IntPtr.Zero;
            Size = 0;
        }

        public static UnmanagedMemory New<T>(int count = 1) where T : struct
        {
            return new UnmanagedMemory(Marshal.SizeOf<T>() * count);
        }
    }

    public class UnmanagedMemory<T> : UnmanagedMemory where T : unmanaged
    {
        public unsafe T* PtrElem => (T*) Ptr;

        public int Stride => Marshal.SizeOf<T>();
        public int Count { get; protected set; } = 0;

        protected UnmanagedMemory() {}

        public UnmanagedMemory(IntPtr ptr, int count = 1) : base(ptr)
        {
            Count = count;
        }

        public UnmanagedMemory(int count = 1)
        {
            Alloc(Stride * count);
            Count = count;
        }

        public unsafe T* GetElement(int index)
        {
            return (T*)(Ptr + index * Stride);
        }

        public unsafe T*[] ToArray()
        {
            var ret = new T*[Count];
            for (int i = 0; i < Count; i++)
                ret[i] = (T*) (Ptr + i * Stride);
            return ret;
        }
    }
}