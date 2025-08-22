namespace RestService.Services
{
    public interface IDatumLezerService
    {
       
        Task<string> sterrebeeldNaam(int dag, int maand);
    }
}
