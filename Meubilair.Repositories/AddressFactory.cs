using Meubilair.Model.Addresses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meubilair.Repositories
{
    internal static class AddressFactory
    {
        #region Field Names

        internal static class FieldNames
        {
            public const string Street = "Street";
            public const string City = "City";
            public const string State = "State";
            public const string PostalCode = "PostalCode";
        }

        #endregion

        internal static Address BuildAddress(IDataReader reader)
        {
            return new Address(reader[FieldNames.Street].ToString(),
                       reader[FieldNames.City].ToString(),
                       reader[FieldNames.State].ToString(),
                       reader[FieldNames.PostalCode].ToString());
        }

    }

}
