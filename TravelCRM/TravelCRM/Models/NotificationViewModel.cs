using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelCRM.Models
{
    public class NotificationViewModel
    {
        public IEnumerable<UserNotification> Notify { get; private set; }

        public NotificationViewModel(IEnumerable<UserNotification> pirates)
        {
            Notify = pirates;
        }
    }


}
