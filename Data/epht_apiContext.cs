﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using epht_api.Models;

namespace epht_api.Data
{
    public class epht_apiContext : DbContext
    {
        public epht_apiContext (DbContextOptions<epht_apiContext> options)
            : base(options)
        {
        }

        public DbSet<epht_api.Models.Topic> Config_Topic_Test { get; set; }

        public DbSet<epht_api.Models.Theme> Config_Theme_Test { get; set; }

        public DbSet<epht_api.Models.Tab> Config_Tab_Test { get; set; }

        public DbSet<epht_api.Models.Tab_ChartConfig> Config_Tab_ChartConfig_Test { get; set; }

        public DbSet<epht_api.Models.Tab_UrlParam> Config_Tab_UrlParam_Test { get; set; }

        public DbSet<epht_api.Models.Tab_MapSet> Config_Tab_MapSet_Test { get; set; }

        public DbSet<epht_api.Models.MapSet_Outfield> Config_MapSet_Outfield_Test { get; set; }

        public DbSet<epht_api.Models.MapSet_ColumnHeader> Config_MapSet_ColumnHeader_Test { get; set; }

        public DbSet<epht_api.Models.MapSet_PopupContent> Config_MapSet_PopupContent_Test { get; set; }
        
        public DbSet<epht_api.Models.MapSet_SetLayer> Config_MapSet_SetLayer_Test { get; set; }

        public DbSet<epht_api.Models.SetLayer_Content> Config_SetLayer_Content_Test { get; set; }

        public DbSet<epht_api.Models.SetLayer_DrawingInfo> Config_SetLayer_DrawingInfo_Test { get; set; }

        public DbSet<epht_api.Models.Tab_ChartDataSet> Config_Tab_ChartDataSet_Test { get; set; }

        public DbSet<epht_api.Models.Tab_DefaultSetName> Config_Tab_DefaultSetName_Test { get; set; }

        public DbSet<epht_api.Models.Tab_Stratification> Config_Tab_Stratification_Test { get; set; }

        public DbSet<epht_api.Models.Tab_ColumnHeader> Config_Tab_ColumnHeader_Test { get; set; }
    }
}
