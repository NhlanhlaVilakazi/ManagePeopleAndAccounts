using AutoMapper;
using ManagePeople.Data.DataModels.User;
using ManagePeople.ViewModels.User;

namespace ManagePeople.Business.MappingProfiles
{
    public class ObjectMapper
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserInfoViewModel, UserInfo>().ReverseMap();
            });

            var mapper = config.CreateMapper();
            return mapper;
        });

        public static IMapper Mapper => Lazy.Value;
    }
}
