using PersonalWebsite.Application.Common.Repositories;

namespace PersonalWebsite.Application.Profile.Query;

public class GetProfileHandler
{

    private readonly IProfileRepository _profileRepository;

    public GetProfileHandler(IProfileRepository profileRepository)
    {
        _profileRepository = profileRepository;
    }

    public GetProfileResponse Handle(GetProfile getProfileCommand)
    {
        var profile = _profileRepository.GetProfile();

        return GetProfileResponse.FromProfile(profile);
        
    }
}