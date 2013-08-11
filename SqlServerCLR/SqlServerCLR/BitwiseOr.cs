using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.SqlServer.Server;
using System.Data.SqlTypes;

namespace SqlServerCLR
{
    [Serializable, SqlUserDefinedAggregate(Format.Native, Name = "BitwiseOr")]
    public struct BitwiseOr
    {
        long mask;
        public void Init()
        {
            mask = 0;
        }

        public void Accumulate(SqlInt64 value)
        {
            if (value.IsNull)
                return;
            mask |= value.Value;
        }

        public void Merge(BitwiseOr bo)
        {
            mask |= bo.mask;
        }

        public SqlInt64 Terminate()
        {
            return new SqlInt64(mask);
        }
    }
}
