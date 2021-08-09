using System;
using System.Collections.Generic;
using System.Text;

namespace FehEditor.JSON
{
    public class SRPGMapJson
    {
        public uint archive_size;
        public uint ptr_list_offset;
        public uint ptr_list_length;
        public uint tag_list_length;
        public uint uk1;
        public uint uk2;
        public ulong magic;
        public uint uk3;
        public uint highest_score;
        public ulong addr_field;
        public ulong addr_player_pos;
        public ulong addr_units;
        public uint player_count;
        public uint unit_count;
        public byte turns_to_win;
        public byte last_enemy_phase;
        public byte turns_to_defend;
        public Field field;
        public Position[] player_pos;
        public Unit[] units;
    }

    public class Field
    {
        public string id;
        public uint width;
        public uint height;
        public byte base_terrain;
        public byte[][] terrain;
        
    }

    public class Position
    {
        public ushort x;
        public ushort y;
    }

    public class Unit
    {
        public string id_tag;
        public string[] skills;
        public string accessory;
        public Position pos;
        public byte rarity;
        public byte lv;
        public byte cooldown_count;
        public byte uk = 100;
        public Stats stats;
        public byte start_turn;
        public byte movement_group;
        public byte movement_delay;
        public byte break_terrain;
        public byte tether;
        public byte true_lv;
        public byte is_enemy;
        public string spawn_check;
        public byte spawn_count;
        public byte spawn_turns;
        public byte spawn_target_remain;
        public byte spawn_target_kills;
    }

    public class Stats
    {
        public short hp;
        public short atk;
        public short spd;
        public short def;
        public short res;
    }

}
