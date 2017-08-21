using ComLog.Dto;

namespace ComLog.WinForms.Interfaces.Common
{
    public interface ITypedView<T, TK> : IRefreshedView, IEnterMode where T : class, IDto<TK>
    {
        #region Details

        TK Id { get; set; }

        #endregion
    }
}