namespace MAUIsland;
public interface IColorPicker
{
    Task PickColorForAsync(object context, string bindingPath);
}
