using System.IO;

namespace Ekm.Mobile.Extensions
{
  public static class ByteArrayExtensions
  {
    public static MemoryStream AsMemoryStream(this byte[] bytes)
    {
      return new MemoryStream(bytes);
    }
  }
}
