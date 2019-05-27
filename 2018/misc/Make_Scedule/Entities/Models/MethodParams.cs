using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class MethodParams
    {
        public int Id { get; private set; }
        public string MethodName { get; set; }
        public List<Role> Roles { get; set; }
        public List<Subscriptions> Subscription { get; set; }
    }
}
