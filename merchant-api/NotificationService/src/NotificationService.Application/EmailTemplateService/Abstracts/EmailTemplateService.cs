namespace NotificationService.Application.Services.Templates
{
    public abstract class EmailTemplateService<T> : IEmailTemplateService<T>
    {
        protected const string EmailPath = "templates/";

        public abstract Task<string> GenerateEmailTemplate(T email);
    }
}