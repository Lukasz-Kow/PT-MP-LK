

namespace Presentations
{
    interface IErrorPopup
    {
        void InformError(string message);

        void InformSuccess(string message);

        string GetRecentMessage();
    }
}
