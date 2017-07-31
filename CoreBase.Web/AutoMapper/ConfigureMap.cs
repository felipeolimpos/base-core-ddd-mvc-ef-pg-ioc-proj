using AutoMapper;
using CoreBase.Infra.Cross.AutoMapper;

namespace CoreBase.Web.AutoMapper
{
    public static class ConfigureMap
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<DataMappingProfile>();
                cfg.AddProfile<WebMappingProfile>();
            });
        }
    }
}
