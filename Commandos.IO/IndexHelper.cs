﻿using System.IO;
using Commandos.IO.Entities;

namespace Commandos.IO
{
    public enum TokenType
    {
        SingleValue,
        MultipleRecords,
        MultipleValues,
        MultipleList
    }

    public static class IndexHelper
    {
        public static (int startIndex, int endIndex) GetPositionIndexes(string[] tokens, int startPoint)
        {
            return GetRecordIndexes(tokens, StringConstants.Position, startPoint, TokenType.SingleValue);
        }

        //internal static (int startIndex, int endIndex, int count, int elementCount) GetListIndexes(string[] tokens, string tokenName, int startPoint, TokenType tokenType)
        //{
        //    var startIndex = GetStartIndex(tokens, tokenName, startPoint);
        //    //if (tokenType == TokenType.MultipleValues)
        //    //{
        //    //    var indexes = (startIndex, startIndex + 1);
        //    //}
        //    //else if (tokenType == TokenType.MultipleList)
        //    //    return (startIndex, GetRecordIndexes(tokens, startIndex, "(", ")").endIndex);
        //    //else if (tokenType == TokenType.MultipleRecords)
        //    //    return (startIndex, GetRecordIndexes(tokens, startIndex, "[", "]").endIndex);
        //    throw new InvalidDataException($"Invalid tokenType {tokenType} for tokenName {tokenName},");
        //}

        private static int GetStartIndex(string[] tokens, string tokenName, int startPoint)
        {
            for (var i = startPoint; i < tokens.Length; i++)
                if (tokens[i] == tokenName)
                    return i;
            throw new InvalidDataException($"Token {tokenName} not found,");
        }

        private static int GetStartIndex(string[] tokens, int startPoint)
        {
            for (var i = startPoint; i < tokens.Length; i++)
                if (tokens[i].StartsWith(".", System.StringComparison.CurrentCultureIgnoreCase))
                    return i;
            throw new InvalidDataException($"Token not found,");
        }

        internal static (int startIndex, int endIndex, TokenValueType tokenValueType) GetIndexes(string[] tokens, int startPoint)
        {
            var startIndex = GetStartIndex(tokens, startPoint);
            if (tokens[startIndex + 1] == "[" || tokens[startIndex + 1] == "]")
                return (startIndex, GetRecordIndexes(tokens, startIndex, "[", "]"), TokenValueType.MultipleRecords);
            else if (tokens[startIndex + 1] == "(" || tokens[startIndex + 1] == ")")
            {
                if (tokens[startIndex + 2] == "(")
                    return (startIndex, GetRecordIndexes(tokens, startIndex, "(", ")"), TokenValueType.MultipleList);
                else if (tokens[startIndex + 2] == "[")
                    return (startIndex, GetRecordIndexes(tokens, startIndex, "(", ")"), TokenValueType.MultipleRecords);
                else
                    return (startIndex, GetRecordIndexes(tokens, startIndex, "(", ")"), TokenValueType.MultipleValues);
            }
            else
                return (startIndex, startIndex + 1, TokenValueType.SingleValue);
        }

        internal static (int startIndex, int endIndex) GetRecordIndexes(string[] tokens, string tokenName, int startPoint, TokenType tokenType)
        {
            var startIndex = GetStartIndex(tokens, tokenName, startPoint);
            if (tokenType == TokenType.SingleValue)
                return (startIndex, startIndex + 1);
            else if (tokenType == TokenType.MultipleList)
                return (startIndex, GetRecordIndexes(tokens, startIndex, "(", ")"));
            else if (tokenType == TokenType.MultipleRecords)
                return (startIndex, GetRecordIndexes(tokens, startIndex, "[", "]"));
            throw new InvalidDataException($"Invalid tokenType {tokenType} for tokenName {tokenName},");
        }

        private static int GetRecordIndexes(string[] tokens, int startIndex, string startingElement, string endingElement)
        {
            var counter = 0;
            for (var i = startIndex + 1; i < tokens.Length; i++)
            {
                if (tokens[i] == startingElement)
                    counter++;
                else if (tokens[i] == endingElement)
                {
                    counter--;
                    if (counter == 0)
                        return i;
                }
            }
            throw new InvalidDataException("Invalid data,");
        }
    }
}
