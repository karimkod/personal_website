using PersonalWebsite.Domain.Entities;
namespace PersonalWebsite.Application.Common.Repositories;

public interface IProfileRepository
{
    Domain.Entities.Profile GetProfile();
}