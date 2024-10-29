using System.Collections.ObjectModel;

namespace Utilities
{
    public class Constants
    {
        public const string ImageUrl = @"\Assets\Products\";

        public const string ShoppingCartSession = "ShoppingCartSession";

        public const string AdminRole = "admin";
        public const string CustomerRole = "customer";

        public const string AdminEmail = "andres.chacon.mora@covao.ed.cr";

        public const string CategoryElementName = "Category";
        public const string AppTypeElementName = "AppType";

        public const string SuccessStatus = "Success";
        public const string ErrorStatus = "Error";

        public const string ApprovedStatus = "Aprobado";
        public const string PendingStatus = "Pendiente";
        public const string ProcessingStatus = "Procesando";
        public const string SentStatus = "Enviado";
        public const string CanceledStatus = "Cancelado";
        public const string ReturnedStatus = "Devuelto";

        public static readonly IEnumerable<string> StatusesList = new ReadOnlyCollection<string>(
            new List<string>
            {
                ApprovedStatus, PendingStatus, ProcessingStatus, SentStatus, CanceledStatus, ReturnedStatus
            }
        );
    }
}
