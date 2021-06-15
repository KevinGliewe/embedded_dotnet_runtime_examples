// Generate using 'gsource --in .\Pointer.cs --out [in]'

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace GCore.NativeInterop
{
    public interface IPointer<T> where T : struct
    {
        IntPtr Ptr { get; }
        int ElementSize { get; }

        T GetElement(int index);

        T[] ToArray(int size);
    }

    public interface IPointerN<T> : IPointer<T>, IEnumerable<T> where T : struct
    {
        int Size { get; }

        T[] ToArray();
    }

    public struct Pointer<T> : IPointer<T> where T: struct
    {
        private IntPtr _p;

        public IntPtr Ptr =>_p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size)
        {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }
    }

    /*<[T42 Dst="..:out"]>
    <#for(int i = 0; i < 256; i++) {#>
    public struct Pointer<#=i#><T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => <#=i#>;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    <#}#>
    <[/T42]>*/
    // <[Raw Name="out"]>

    public struct Pointer0<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 0;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer1<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 1;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer2<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 2;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer3<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 3;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer4<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 4;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer5<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 5;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer6<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 6;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer7<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 7;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer8<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 8;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer9<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 9;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer10<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 10;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer11<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 11;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer12<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 12;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer13<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 13;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer14<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 14;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer15<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 15;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer16<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 16;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer17<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 17;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer18<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 18;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer19<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 19;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer20<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 20;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer21<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 21;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer22<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 22;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer23<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 23;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer24<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 24;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer25<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 25;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer26<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 26;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer27<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 27;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer28<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 28;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer29<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 29;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer30<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 30;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer31<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 31;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer32<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 32;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer33<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 33;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer34<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 34;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer35<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 35;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer36<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 36;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer37<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 37;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer38<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 38;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer39<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 39;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer40<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 40;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer41<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 41;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer42<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 42;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer43<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 43;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer44<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 44;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer45<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 45;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer46<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 46;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer47<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 47;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer48<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 48;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer49<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 49;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer50<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 50;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer51<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 51;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer52<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 52;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer53<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 53;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer54<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 54;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer55<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 55;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer56<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 56;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer57<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 57;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer58<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 58;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer59<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 59;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer60<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 60;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer61<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 61;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer62<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 62;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer63<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 63;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer64<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 64;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer65<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 65;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer66<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 66;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer67<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 67;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer68<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 68;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer69<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 69;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer70<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 70;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer71<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 71;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer72<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 72;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer73<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 73;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer74<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 74;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer75<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 75;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer76<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 76;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer77<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 77;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer78<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 78;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer79<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 79;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer80<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 80;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer81<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 81;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer82<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 82;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer83<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 83;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer84<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 84;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer85<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 85;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer86<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 86;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer87<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 87;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer88<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 88;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer89<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 89;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer90<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 90;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer91<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 91;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer92<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 92;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer93<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 93;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer94<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 94;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer95<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 95;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer96<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 96;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer97<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 97;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer98<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 98;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer99<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 99;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer100<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 100;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer101<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 101;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer102<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 102;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer103<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 103;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer104<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 104;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer105<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 105;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer106<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 106;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer107<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 107;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer108<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 108;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer109<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 109;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer110<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 110;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer111<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 111;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer112<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 112;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer113<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 113;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer114<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 114;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer115<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 115;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer116<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 116;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer117<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 117;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer118<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 118;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer119<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 119;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer120<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 120;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer121<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 121;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer122<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 122;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer123<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 123;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer124<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 124;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer125<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 125;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer126<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 126;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer127<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 127;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer128<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 128;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer129<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 129;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer130<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 130;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer131<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 131;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer132<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 132;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer133<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 133;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer134<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 134;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer135<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 135;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer136<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 136;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer137<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 137;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer138<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 138;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer139<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 139;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer140<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 140;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer141<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 141;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer142<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 142;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer143<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 143;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer144<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 144;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer145<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 145;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer146<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 146;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer147<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 147;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer148<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 148;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer149<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 149;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer150<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 150;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer151<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 151;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer152<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 152;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer153<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 153;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer154<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 154;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer155<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 155;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer156<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 156;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer157<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 157;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer158<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 158;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer159<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 159;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer160<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 160;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer161<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 161;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer162<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 162;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer163<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 163;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer164<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 164;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer165<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 165;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer166<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 166;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer167<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 167;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer168<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 168;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer169<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 169;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer170<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 170;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer171<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 171;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer172<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 172;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer173<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 173;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer174<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 174;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer175<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 175;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer176<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 176;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer177<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 177;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer178<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 178;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer179<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 179;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer180<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 180;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer181<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 181;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer182<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 182;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer183<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 183;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer184<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 184;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer185<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 185;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer186<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 186;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer187<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 187;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer188<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 188;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer189<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 189;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer190<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 190;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer191<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 191;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer192<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 192;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer193<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 193;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer194<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 194;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer195<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 195;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer196<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 196;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer197<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 197;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer198<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 198;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer199<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 199;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer200<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 200;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer201<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 201;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer202<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 202;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer203<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 203;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer204<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 204;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer205<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 205;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer206<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 206;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer207<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 207;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer208<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 208;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer209<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 209;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer210<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 210;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer211<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 211;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer212<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 212;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer213<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 213;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer214<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 214;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer215<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 215;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer216<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 216;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer217<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 217;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer218<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 218;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer219<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 219;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer220<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 220;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer221<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 221;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer222<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 222;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer223<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 223;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer224<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 224;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer225<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 225;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer226<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 226;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer227<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 227;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer228<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 228;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer229<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 229;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer230<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 230;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer231<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 231;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer232<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 232;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer233<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 233;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer234<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 234;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer235<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 235;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer236<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 236;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer237<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 237;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer238<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 238;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer239<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 239;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer240<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 240;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer241<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 241;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer242<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 242;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer243<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 243;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer244<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 244;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer245<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 245;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer246<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 246;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer247<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 247;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer248<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 248;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer249<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 249;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer250<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 250;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer251<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 251;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer252<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 252;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer253<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 253;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer254<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 254;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct Pointer255<T> : IPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 255;

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    // <[/Raw]>
}