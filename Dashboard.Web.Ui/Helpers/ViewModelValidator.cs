using Hub.Web.ViewModels;

namespace Dashboard.Web.Ui.Helpers
{
    public static class ViewModelValidator
    {
        public static bool IsValid(ApiResponseViewModel viewModel)
        {
            return viewModel != null && viewModel.Success;
        }
    }
}