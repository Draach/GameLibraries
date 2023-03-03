namespace Game.Skills
{
    // TODO: Consider adding: Duration, CastingTime, Range,
    // TODO: Review summary.
    /// <summary>
    /// An ability.
    /// </summary>
    public interface ISkill
    {
        /// <summary>
        /// Determines if it is a Magical or Physical <see cref="ISkill"/>. See <see cref="SkillType"/>.
        /// </summary>
        SkillType SkillType { get; }

        SkillSchool SkillSchool { get; }

        /// <summary>
        /// The <see cref="ISkill"/> name.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// A user friendly description of the <see cref="ISkill"/>.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// An advanced and detailed description of the <see cref="ISkill"/> with numeric representations.
        /// </summary>
        string Effect { get; }

        /// <summary>
        /// Wait time needed to re-utilize or re-enable the <see cref="ISkill"/>. 
        /// </summary>
        float Cooldown { get; }

        /// <summary>
        /// Determines if the <see cref="ISkill"/> requires user input.
        /// </summary>
        bool IsPassive { get; }
    }
}