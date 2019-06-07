﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intersect.Enums;

namespace Intersect.GameObjects.Events
{
    public enum ConditionTypes
    {
        PlayerSwitch = 0,
        PlayerVariable,
        ServerSwitch,
        ServerVariable,
        HasItem,
        ClassIs,
        KnowsSpell,
        LevelOrStat,
        SelfSwitch, //Only works for events.. not for checking if you can destroy a resource or something like that
        AccessIs,
        TimeBetween,
        CanStartQuest,
        QuestInProgress,
        QuestCompleted,
        NoNpcsOnMap,
        GenderIs,
        MapIs,
        IsItemEquipped,
    }

    public class Condition
    {
        public virtual ConditionTypes Type { get; }
        public bool Negated { get; set; }
    }

    public class PlayerSwitchCondition : Condition
    {
        public override ConditionTypes Type { get; } = ConditionTypes.PlayerSwitch;
        public Guid SwitchId { get; set; }
        public bool Value { get; set; }
    }

    public class PlayerVariableCondition : Condition
    {
        public override ConditionTypes Type { get; } = ConditionTypes.PlayerVariable;
        public Guid VariableId { get; set; }
        public VariableComparators Comparator { get; set; } = VariableComparators.Equal;
        public VariableCompareTypes CompareType { get; set; } = VariableCompareTypes.StaticValue;
        public long Value { get; set; }
        public Guid CompareVariableId { get; set; }
    }

    public class ServerSwitchCondition : Condition
    {
        public override ConditionTypes Type { get; } = ConditionTypes.ServerSwitch;
        public Guid SwitchId { get; set; }
        public bool Value { get; set; }
    }

    public class ServerVariableCondition : Condition
    {
        public override ConditionTypes Type { get; } = ConditionTypes.ServerVariable;
        public Guid VariableId { get; set; }
        public VariableComparators Comparator { get; set; } = VariableComparators.Equal;
        public VariableCompareTypes CompareType { get; set; } = VariableCompareTypes.StaticValue;
        public long Value { get; set; }
        public Guid CompareVariableId { get; set; }
    }

    public class HasItemCondition : Condition
    {
        public override ConditionTypes Type { get; } = ConditionTypes.HasItem;
        public Guid ItemId { get; set; }
        public int Quantity { get; set; }
    }

    public class ClassIsCondition : Condition
    {
        public override ConditionTypes Type { get; } = ConditionTypes.ClassIs;
        public Guid ClassId { get; set; }
    }

    public class KnowsSpellCondition : Condition
    {
        public override ConditionTypes Type { get; } = ConditionTypes.KnowsSpell;
        public Guid SpellId { get; set; }
    }

    public class LevelOrStatCondition : Condition
    {
        public override ConditionTypes Type { get; } = ConditionTypes.LevelOrStat;
        public bool ComparingLevel { get; set; }
        public Stats Stat { get; set; }
        public VariableComparators Comparator { get; set; } = VariableComparators.Equal;
        public int Value { get; set; }
        public bool IgnoreBuffs { get; set; }
    }

    public class SelfSwitchCondition : Condition
    {
        public override ConditionTypes Type { get; } = ConditionTypes.SelfSwitch;
        public int SwitchIndex { get; set; } //0 through 3
        public bool Value { get; set; }
    }

    public class AccessIsCondition : Condition
    {
        public override ConditionTypes Type { get; } = ConditionTypes.AccessIs;
        public Access Access { get; set; }
    }

    public class TimeBetweenCondition : Condition
    {
        public override ConditionTypes Type { get; } = ConditionTypes.TimeBetween;
        public int[] Ranges { get; set; } = new int[2];
    }

    public class CanStartQuestCondition : Condition
    {
        public override ConditionTypes Type { get; } = ConditionTypes.CanStartQuest;
        public Guid QuestId { get; set; }
    }

    public class QuestInProgressCondition : Condition
    {
        public override ConditionTypes Type { get; } = ConditionTypes.QuestInProgress;
        public Guid QuestId { get; set; }
        public QuestProgressState Progress { get; set; } = QuestProgressState.OnAnyTask;
        public Guid TaskId { get; set; }
    }

    public class QuestCompletedCondition : Condition
    {
        public override ConditionTypes Type { get; } = ConditionTypes.QuestCompleted;
        public Guid QuestId { get; set; }
    }

    public class NoNpcsOnMapCondition : Condition
    {
        public override ConditionTypes Type { get; } = ConditionTypes.NoNpcsOnMap;
    }

    public class GenderIsCondition : Condition
    {
        public override ConditionTypes Type { get; } = ConditionTypes.GenderIs;
        public Gender Gender { get; set; } = Gender.Male;
    }

    public class MapIsCondition : Condition
    {
        public override ConditionTypes Type { get; } = ConditionTypes.MapIs;
        public Guid MapId { get; set; }
    }

    public class IsItemEquippedCondition : Condition
    {
        public override ConditionTypes Type { get; } = ConditionTypes.IsItemEquipped;
        public Guid ItemId { get; set; }
    }
}
