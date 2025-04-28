using StarColonies.Domains;

namespace StarColonies.Infrastructures.Mappers;

public class JobNameMapper
{
    public static int ToInt(JobName jobName)
    {
        return (int)jobName;
    }

    public static JobName ToJobName(int jobName)
    {
        switch (jobName)
        {
            case 0 : return JobName.Ingenieur; 
            case 1 : return JobName.Soldat;
            case 2 : return JobName.Scientifique;
            default: return JobName.Medecin;
        }
    }
}