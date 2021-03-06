﻿class PossessiveCaseFormatter
{
    static convert(value: string): string
    {
        if (value === undefined || value === null)
            throw new Error('Argument empty');

        let lastChar = value.substr(value.length - 1).toLowerCase();
        if (lastChar === "s")
        {
            return value + "\'";
        }
        return value + "\'s";
    }
}