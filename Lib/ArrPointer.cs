// Generate using 'gsource --in .\ArrPointer.cs --out [in]'

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace GCore.NativeInterop
{
    public interface IArrPointer<T> where T : struct
    {
        IntPtr Ptr { get; }
        int ElementSize { get; }

        T GetElement(int index);

        T[] ToArray(int size);
    }

    public interface IArrPointerN<T> : IArrPointer<T>, IEnumerable<T> where T : struct
    {
        int Size { get; }

        T[] ToArray();
    }

    public struct ArrPointer<T> : IArrPointer<T> where T : struct
    {
        private IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public ArrPointer(IntPtr p) {
            _p = p;
        }

        public T GetElement(int index) {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }
    }

    /*<[T42 Dst="..:out"]>
    <#for(int i = 0; i < 256; i++) {#>
    public struct ArrPointer<#=i#><T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => <#=i#>;

        public ArrPointer<#=i#>(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
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

    public struct ArrPointer0<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 0;

        public ArrPointer0(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer1<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 1;

        public ArrPointer1(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer2<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 2;

        public ArrPointer2(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer3<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 3;

        public ArrPointer3(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer4<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 4;

        public ArrPointer4(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer5<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 5;

        public ArrPointer5(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer6<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 6;

        public ArrPointer6(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer7<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 7;

        public ArrPointer7(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer8<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 8;

        public ArrPointer8(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer9<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 9;

        public ArrPointer9(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer10<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 10;

        public ArrPointer10(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer11<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 11;

        public ArrPointer11(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer12<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 12;

        public ArrPointer12(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer13<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 13;

        public ArrPointer13(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer14<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 14;

        public ArrPointer14(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer15<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 15;

        public ArrPointer15(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer16<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 16;

        public ArrPointer16(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer17<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 17;

        public ArrPointer17(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer18<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 18;

        public ArrPointer18(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer19<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 19;

        public ArrPointer19(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer20<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 20;

        public ArrPointer20(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer21<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 21;

        public ArrPointer21(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer22<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 22;

        public ArrPointer22(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer23<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 23;

        public ArrPointer23(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer24<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 24;

        public ArrPointer24(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer25<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 25;

        public ArrPointer25(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer26<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 26;

        public ArrPointer26(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer27<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 27;

        public ArrPointer27(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer28<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 28;

        public ArrPointer28(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer29<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 29;

        public ArrPointer29(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer30<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 30;

        public ArrPointer30(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer31<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 31;

        public ArrPointer31(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer32<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 32;

        public ArrPointer32(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer33<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 33;

        public ArrPointer33(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer34<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 34;

        public ArrPointer34(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer35<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 35;

        public ArrPointer35(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer36<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 36;

        public ArrPointer36(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer37<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 37;

        public ArrPointer37(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer38<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 38;

        public ArrPointer38(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer39<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 39;

        public ArrPointer39(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer40<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 40;

        public ArrPointer40(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer41<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 41;

        public ArrPointer41(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer42<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 42;

        public ArrPointer42(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer43<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 43;

        public ArrPointer43(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer44<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 44;

        public ArrPointer44(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer45<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 45;

        public ArrPointer45(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer46<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 46;

        public ArrPointer46(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer47<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 47;

        public ArrPointer47(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer48<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 48;

        public ArrPointer48(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer49<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 49;

        public ArrPointer49(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer50<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 50;

        public ArrPointer50(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer51<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 51;

        public ArrPointer51(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer52<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 52;

        public ArrPointer52(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer53<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 53;

        public ArrPointer53(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer54<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 54;

        public ArrPointer54(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer55<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 55;

        public ArrPointer55(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer56<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 56;

        public ArrPointer56(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer57<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 57;

        public ArrPointer57(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer58<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 58;

        public ArrPointer58(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer59<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 59;

        public ArrPointer59(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer60<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 60;

        public ArrPointer60(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer61<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 61;

        public ArrPointer61(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer62<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 62;

        public ArrPointer62(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer63<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 63;

        public ArrPointer63(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer64<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 64;

        public ArrPointer64(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer65<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 65;

        public ArrPointer65(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer66<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 66;

        public ArrPointer66(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer67<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 67;

        public ArrPointer67(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer68<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 68;

        public ArrPointer68(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer69<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 69;

        public ArrPointer69(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer70<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 70;

        public ArrPointer70(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer71<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 71;

        public ArrPointer71(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer72<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 72;

        public ArrPointer72(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer73<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 73;

        public ArrPointer73(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer74<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 74;

        public ArrPointer74(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer75<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 75;

        public ArrPointer75(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer76<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 76;

        public ArrPointer76(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer77<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 77;

        public ArrPointer77(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer78<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 78;

        public ArrPointer78(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer79<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 79;

        public ArrPointer79(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer80<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 80;

        public ArrPointer80(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer81<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 81;

        public ArrPointer81(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer82<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 82;

        public ArrPointer82(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer83<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 83;

        public ArrPointer83(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer84<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 84;

        public ArrPointer84(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer85<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 85;

        public ArrPointer85(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer86<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 86;

        public ArrPointer86(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer87<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 87;

        public ArrPointer87(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer88<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 88;

        public ArrPointer88(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer89<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 89;

        public ArrPointer89(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer90<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 90;

        public ArrPointer90(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer91<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 91;

        public ArrPointer91(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer92<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 92;

        public ArrPointer92(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer93<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 93;

        public ArrPointer93(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer94<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 94;

        public ArrPointer94(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer95<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 95;

        public ArrPointer95(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer96<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 96;

        public ArrPointer96(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer97<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 97;

        public ArrPointer97(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer98<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 98;

        public ArrPointer98(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer99<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 99;

        public ArrPointer99(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer100<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 100;

        public ArrPointer100(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer101<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 101;

        public ArrPointer101(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer102<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 102;

        public ArrPointer102(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer103<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 103;

        public ArrPointer103(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer104<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 104;

        public ArrPointer104(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer105<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 105;

        public ArrPointer105(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer106<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 106;

        public ArrPointer106(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer107<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 107;

        public ArrPointer107(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer108<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 108;

        public ArrPointer108(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer109<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 109;

        public ArrPointer109(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer110<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 110;

        public ArrPointer110(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer111<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 111;

        public ArrPointer111(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer112<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 112;

        public ArrPointer112(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer113<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 113;

        public ArrPointer113(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer114<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 114;

        public ArrPointer114(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer115<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 115;

        public ArrPointer115(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer116<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 116;

        public ArrPointer116(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer117<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 117;

        public ArrPointer117(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer118<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 118;

        public ArrPointer118(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer119<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 119;

        public ArrPointer119(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer120<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 120;

        public ArrPointer120(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer121<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 121;

        public ArrPointer121(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer122<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 122;

        public ArrPointer122(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer123<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 123;

        public ArrPointer123(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer124<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 124;

        public ArrPointer124(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer125<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 125;

        public ArrPointer125(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer126<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 126;

        public ArrPointer126(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer127<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 127;

        public ArrPointer127(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer128<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 128;

        public ArrPointer128(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer129<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 129;

        public ArrPointer129(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer130<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 130;

        public ArrPointer130(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer131<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 131;

        public ArrPointer131(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer132<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 132;

        public ArrPointer132(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer133<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 133;

        public ArrPointer133(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer134<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 134;

        public ArrPointer134(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer135<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 135;

        public ArrPointer135(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer136<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 136;

        public ArrPointer136(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer137<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 137;

        public ArrPointer137(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer138<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 138;

        public ArrPointer138(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer139<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 139;

        public ArrPointer139(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer140<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 140;

        public ArrPointer140(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer141<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 141;

        public ArrPointer141(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer142<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 142;

        public ArrPointer142(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer143<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 143;

        public ArrPointer143(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer144<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 144;

        public ArrPointer144(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer145<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 145;

        public ArrPointer145(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer146<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 146;

        public ArrPointer146(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer147<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 147;

        public ArrPointer147(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer148<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 148;

        public ArrPointer148(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer149<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 149;

        public ArrPointer149(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer150<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 150;

        public ArrPointer150(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer151<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 151;

        public ArrPointer151(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer152<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 152;

        public ArrPointer152(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer153<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 153;

        public ArrPointer153(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer154<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 154;

        public ArrPointer154(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer155<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 155;

        public ArrPointer155(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer156<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 156;

        public ArrPointer156(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer157<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 157;

        public ArrPointer157(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer158<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 158;

        public ArrPointer158(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer159<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 159;

        public ArrPointer159(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer160<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 160;

        public ArrPointer160(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer161<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 161;

        public ArrPointer161(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer162<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 162;

        public ArrPointer162(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer163<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 163;

        public ArrPointer163(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer164<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 164;

        public ArrPointer164(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer165<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 165;

        public ArrPointer165(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer166<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 166;

        public ArrPointer166(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer167<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 167;

        public ArrPointer167(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer168<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 168;

        public ArrPointer168(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer169<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 169;

        public ArrPointer169(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer170<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 170;

        public ArrPointer170(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer171<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 171;

        public ArrPointer171(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer172<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 172;

        public ArrPointer172(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer173<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 173;

        public ArrPointer173(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer174<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 174;

        public ArrPointer174(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer175<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 175;

        public ArrPointer175(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer176<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 176;

        public ArrPointer176(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer177<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 177;

        public ArrPointer177(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer178<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 178;

        public ArrPointer178(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer179<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 179;

        public ArrPointer179(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer180<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 180;

        public ArrPointer180(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer181<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 181;

        public ArrPointer181(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer182<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 182;

        public ArrPointer182(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer183<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 183;

        public ArrPointer183(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer184<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 184;

        public ArrPointer184(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer185<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 185;

        public ArrPointer185(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer186<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 186;

        public ArrPointer186(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer187<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 187;

        public ArrPointer187(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer188<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 188;

        public ArrPointer188(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer189<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 189;

        public ArrPointer189(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer190<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 190;

        public ArrPointer190(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer191<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 191;

        public ArrPointer191(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer192<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 192;

        public ArrPointer192(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer193<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 193;

        public ArrPointer193(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer194<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 194;

        public ArrPointer194(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer195<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 195;

        public ArrPointer195(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer196<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 196;

        public ArrPointer196(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer197<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 197;

        public ArrPointer197(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer198<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 198;

        public ArrPointer198(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer199<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 199;

        public ArrPointer199(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer200<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 200;

        public ArrPointer200(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer201<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 201;

        public ArrPointer201(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer202<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 202;

        public ArrPointer202(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer203<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 203;

        public ArrPointer203(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer204<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 204;

        public ArrPointer204(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer205<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 205;

        public ArrPointer205(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer206<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 206;

        public ArrPointer206(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer207<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 207;

        public ArrPointer207(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer208<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 208;

        public ArrPointer208(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer209<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 209;

        public ArrPointer209(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer210<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 210;

        public ArrPointer210(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer211<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 211;

        public ArrPointer211(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer212<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 212;

        public ArrPointer212(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer213<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 213;

        public ArrPointer213(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer214<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 214;

        public ArrPointer214(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer215<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 215;

        public ArrPointer215(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer216<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 216;

        public ArrPointer216(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer217<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 217;

        public ArrPointer217(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer218<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 218;

        public ArrPointer218(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer219<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 219;

        public ArrPointer219(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer220<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 220;

        public ArrPointer220(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer221<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 221;

        public ArrPointer221(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer222<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 222;

        public ArrPointer222(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer223<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 223;

        public ArrPointer223(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer224<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 224;

        public ArrPointer224(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer225<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 225;

        public ArrPointer225(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer226<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 226;

        public ArrPointer226(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer227<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 227;

        public ArrPointer227(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer228<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 228;

        public ArrPointer228(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer229<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 229;

        public ArrPointer229(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer230<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 230;

        public ArrPointer230(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer231<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 231;

        public ArrPointer231(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer232<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 232;

        public ArrPointer232(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer233<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 233;

        public ArrPointer233(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer234<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 234;

        public ArrPointer234(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer235<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 235;

        public ArrPointer235(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer236<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 236;

        public ArrPointer236(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer237<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 237;

        public ArrPointer237(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer238<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 238;

        public ArrPointer238(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer239<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 239;

        public ArrPointer239(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer240<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 240;

        public ArrPointer240(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer241<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 241;

        public ArrPointer241(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer242<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 242;

        public ArrPointer242(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer243<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 243;

        public ArrPointer243(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer244<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 244;

        public ArrPointer244(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer245<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 245;

        public ArrPointer245(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer246<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 246;

        public ArrPointer246(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer247<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 247;

        public ArrPointer247(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer248<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 248;

        public ArrPointer248(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer249<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 249;

        public ArrPointer249(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer250<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 250;

        public ArrPointer250(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer251<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 251;

        public ArrPointer251(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer252<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 252;

        public ArrPointer252(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer253<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 253;

        public ArrPointer253(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer254<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 254;

        public ArrPointer254(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return GetElement(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public struct ArrPointer255<T> : IArrPointerN<T> where T: struct
    {
        public IntPtr _p;

        public IntPtr Ptr => _p;
        public int ElementSize => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        public bool IsValid => _p != IntPtr.Zero;

        public int Size => 255;

        public ArrPointer255(IntPtr p)
        {
            _p = p;
        }

        public T GetElement(int index)
        {
            if (!IsValid)
                throw new Exception("Pointer in not valid: " + _p);
            if (index >= Size)
                throw new IndexOutOfRangeException("Index is out of range " + index);

            var p = _p + ElementSize * index;
            return Marshal.PtrToStructure<T>(p);
        }

        public T[] ToArray(int size) {
            var arr = new T[size];

            for (int i = 0; i < size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public T[] ToArray()
        {
            var arr = new T[Size];

            for (int i = 0; i < Size; i++)
                arr[i] = GetElement(i);

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
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