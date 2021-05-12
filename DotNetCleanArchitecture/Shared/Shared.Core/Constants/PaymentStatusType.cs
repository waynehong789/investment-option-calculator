using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Core.Constants
{
    public static class PaymentStatusType
    {
        public static string Cancelled = "cancelled";
        public static string Processing = "processing";
        public static string RequiresAction = "requires_action";
        public static string RequiresCapture = "requires_capture";
        public static string RequiresConfirmation = "requires_confirmation";
        public static string RequiresPaymentMethod = "requires_payment_method";
        public static string Succeeded = "succeeded";
        public static string Failed = "failed";

    }
}
