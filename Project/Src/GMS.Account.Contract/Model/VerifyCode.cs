using System;
using System.ComponentModel.DataAnnotations.Schema;
using GMS.Framework.Contract;

namespace GMS.Account.Contract
{
    [Serializable]
    [Table("VerifyCode")]
    public class VerifyCode : ModelBase
    {
        public Guid Guid { get; set; }
        public string VerifyText { get; set; }
    }

}



