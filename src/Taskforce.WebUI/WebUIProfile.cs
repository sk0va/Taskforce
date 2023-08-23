using AutoMapper;
using Taskforce.Domain.Tasks;
using Taskforce.WebUI.Tasks;

namespace Taskforce.WebUI;

public class WebUIProfile: Profile
{
    public WebUIProfile()
    {
        CreateMap<Domain.Tasks.Task, TaskModel>();

        CreateMap<TaskModel, CreateTaskCommand>()
            .ForMember(dest => dest.DueDate, opt => opt.MapFrom(src => src.DueDate.Value.UtcDateTime)) 
            .ForMember(dest => dest.CompletedDate, opt => opt.MapFrom(src => src.CompletedDate.Value.UtcDateTime))
            
            .ForMember(dest => dest.CommandId, opt => opt.Ignore());

        CreateMap<TaskModel, UpdateTaskCommand>()
            .ForMember(dest => dest.DueDate, opt => opt.MapFrom(src => src.DueDate.Value.UtcDateTime)) 
            .ForMember(dest => dest.CompletedDate, opt => opt.MapFrom(src => src.CompletedDate.Value.UtcDateTime))
            .ForMember(dest => dest.CommandId, opt => opt.Ignore());
    }
}
