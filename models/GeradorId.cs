using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SnowflakeGenerator;

namespace atetlaAPI.models
{
    public static class GeradorId
    {
        private static readonly Snowflake snowflake;
        static GeradorId()
        {
            Settings settings = new Settings
            {
                MachineID = 1,
                CustomEpoch = new DateTimeOffset(2025, 1, 11, 0, 0, 0, TimeSpan.Zero)
            };

            snowflake = new Snowflake(settings);
        }
        public static long GetId()
        {
            return snowflake.NextID();
        }

    }
}