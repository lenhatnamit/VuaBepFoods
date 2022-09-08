using System;
using System.Collections.Generic;

namespace VuaBepFoodsWeb.ViewModels
{
    public class VM_AccountInfo
    {
        public string accountId { get; set; }
        public string userName { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string fullName { get; set; }
        public string email { get; set; }
        public string avatar { get; set; }
        public int? personId { get; set; }
        public int gender { get; set; }
        public DateTime? birthday { get; set; }
        public string supplierId { get; set; }
        public string parentId { get; set; }
        public string supplierName { get; set; }
        public string domainName { get; set; }
        public List<string> groupName { get; set; }
        public int isManySupplier { get; set; }
        public List<string> roles { get; set; }
    }
}