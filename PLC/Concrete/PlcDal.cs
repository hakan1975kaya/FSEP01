using Core.Utilities.Service;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;
using PLC.Abstract;
using PLC.Helper;
using S7.Net;
using S7.Net.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLC.Concrete
{
    public class PlcDal : IPlcDal
    {
        private IPlcHelper _plcHelper;
        private Plc _plc;
        public PlcDal(IPlcHelper plcHelper)
        {
            _plcHelper = plcHelper;
            _plc = _plcHelper.Plc();
        }
        public object? Read(string variable)
        {
            return _plc.Read(variable);
        }

        public object? Read(DataType dataType, int db, int startByteAdr, VarType varType, int varCount, byte bitAdr = 0)
        {
            return _plc.Read(dataType,db,startByteAdr,varType,varCount,bitAdr);
        }

        public byte[] ReadBytes(DataType dataType, int db, int startByteAdr, int count)
        {
            return _plc.ReadBytes(dataType, db, startByteAdr, count);
        }

        public  void ReadBytes(Span<byte> buffer, DataType dataType, int db, int startByteAdr)
        {
             _plc.ReadBytes(buffer, dataType, db, startByteAdr);
        }

        public int ReadClass(object sourceClass, int db, int startByteAdr = 0)
        {
            return _plc.ReadClass(sourceClass, db, startByteAdr);
        }

        public T? ReadClass<T>(int db, int startByteAdr = 0) where T : class
        {
            return _plc.ReadClass<T>(db, startByteAdr);
        }

        public object?  ReadStruct(Type structType, int db, int startByteAdr = 0)
        {
            return _plc.ReadStruct(structType, db, startByteAdr);
        }

        public T? ReadStruct<T>(int db, int startByteAdr = 0) where T : struct
        {
            return _plc.ReadStruct<T>( db, startByteAdr);
        }

        public void ReadMultipleVars(List<DataItem> dataItems)
        {
             _plc.ReadMultipleVars(dataItems);
        }

        public byte ReadStatus(List<DataItem> dataItems)
        {
            return _plc.ReadStatus();
        }

        public void Write(params DataItem[] dataItems)
        {
            _plc.Write(dataItems);
        }

        public void Write(string variable, object value)
        {
            _plc.Write(variable,value);
        }

        public void Write(DataType dataType, int db, int startByteAdr, object value, int bitAdr = -1)
        {
            _plc.Write(dataType, db, startByteAdr, value, bitAdr);
        }

        public void WriteBit(DataType dataType, int db, int startByteAdr, int bitAdr, bool value)
        {
            _plc.WriteBit(dataType,db,startByteAdr,bitAdr,value);
        }

        public void WriteBit(DataType dataType, int db, int startByteAdr, int bitAdr, int value)
        {
            _plc.WriteBit(dataType, db, startByteAdr, bitAdr, value);
        }

        public void WriteBytes(DataType dataType, int db, int startByteAdr, byte[] value)
        {
            _plc.WriteBytes(dataType, db, startByteAdr, value);
        }

        public void WriteBytes(DataType dataType, int db, int startByteAdr, ReadOnlySpan<byte> value)
        {
            _plc.WriteBytes(dataType, db, startByteAdr, value);
        }

        public void WriteClass(object classValue, int db, int startByteAdr = 0)
        {
            _plc.WriteClass(classValue, db, startByteAdr);
        }

        public void WriteStruct(object structValue, int db, int startByteAdr = 0)
        {
            _plc.WriteStruct(structValue, db, startByteAdr);
        }
    }
}
