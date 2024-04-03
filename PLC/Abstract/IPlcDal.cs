using S7.Net;
using S7.Net.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PLC.Abstract
{
    public interface IPLCDal
    {
        public object? Read(string variable);
        public object? Read(DataType dataType, int db, int startByteAdr, VarType varType, int varCount, byte bitAdr = 0);
        public byte[] ReadBytes(DataType dataType, int db, int startByteAdr, int count);
        public void ReadBytes(Span<byte> buffer, DataType dataType, int db, int startByteAdr);
        public int ReadClass(object sourceClass, int db, int startByteAdr = 0);
        public T? ReadClass<T>(int db, int startByteAdr = 0) where T : class;
        public object? ReadStruct(Type structType, int db, int startByteAdr = 0);
        public T? ReadStruct<T>(int db, int startByteAdr = 0) where T : struct;
        public void ReadMultipleVars(List<DataItem> dataItems);
        public byte ReadStatus(List<DataItem> dataItems);
        public void Write(params DataItem[] dataItems);
        public void Write(string variable, object value);
        public void Write(DataType dataType, int db, int startByteAdr, object value, int bitAdr = -1);
        public void WriteBit(DataType dataType, int db, int startByteAdr, int bitAdr, bool value);
        public void WriteBit(DataType dataType, int db, int startByteAdr, int bitAdr, int value);
        public void WriteBytes(DataType dataType, int db, int startByteAdr, byte[] value);
        public void WriteBytes(DataType dataType, int db, int startByteAdr, ReadOnlySpan<byte> value);
        public void WriteClass(object classValue, int db, int startByteAdr = 0);
        public void WriteStruct(object structValue, int db, int startByteAdr = 0);

    }
}
