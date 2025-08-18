namespace IO.Converters;

public interface IConverter<Tin, Tout> where Tin : class where Tout : class
{
    Tout Convert(Tin input);
}