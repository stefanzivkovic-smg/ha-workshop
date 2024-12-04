﻿using NUnit.Framework;
using System;

namespace CSharp.ExtensionMethods.Tests
{
    [TestFixture]
    public class StringExtensionsTests
    {
        #region Capitalize

        [Test]
        public void Capitalize_Lower_Case_Input_Test()
        {
            var result = "twinkle twinkle little star".Capitalize();
            Assert.AreEqual("Twinkle twinkle little star", result);
        }

        [Test]
        public void Capitalize_Upper_Case_Input_Test()
        {
            var result = "TWINKLE TWINKLE LITTLE STAR".Capitalize();
            Assert.AreEqual("Twinkle twinkle little star", result);
        }

        [Test]
        public void Capitalize_Each_Word_In_Capital_Input_Test()
        {
            var result = "Twinkle Twinkle Little Star".Capitalize();
            Assert.AreEqual("Twinkle twinkle little star", result);
        }

        [Test]
        public void Capitalize_Empty_String_Input_Test()
        {
            var result = string.Empty.Capitalize();
            Assert.AreEqual(string.Empty, result);
        }

        [Test]
        public void Capitalize_Integer_Input_Test()
        {
            var result = "1234567890".Capitalize();
            Assert.AreEqual("1234567890", result);
        }

        [Test]
        public void Capitalize_Special_Symbol_Input_Test()
        {
            var result = "!@#$%^&*()".Capitalize();
            Assert.AreEqual("!@#$%^&*()", result);
        }

        #endregion

        #region GetOccurrenceCount

        [Test]
        public void GetOccurrenceCount_Valid_Occurrence_Test()
        {
            var occurrenceCount = "supercalifragilisticexpealidocious".GetOccurrenceCount("li");
            Assert.AreEqual(3, occurrenceCount);
        }

        [Test]
        public void GetOccurrenceCount_Invalid_Occurrence_Test()
        {
            var occurrenceCount = "prasad".GetOccurrenceCount("xxx");
            Assert.AreEqual(0, occurrenceCount);
        }

        [Test]
        public void GetOccurrenceCount_EmptyString_Search_Occurrence_Test()
        {
            var occurrenceCount = "xxx".GetOccurrenceCount(string.Empty);
            Assert.AreEqual(0, occurrenceCount);
        }

        [Test]
        public void GetOccurrenceCount_EmptyString_Input_Occurrence_Test()
        {
            var occurrenceCount = string.Empty.GetOccurrenceCount("Prasad");
            Assert.AreEqual(0, occurrenceCount);
        }

        [Test]
        public void GetOccurrenceCount_Empty_Input_Empty_Search_Occurrence_Test()
        {
            var occurrenceCount = string.Empty.GetOccurrenceCount(string.Empty);
            Assert.AreEqual(1, occurrenceCount);
        }

        #endregion

        #region GetWordCount

        [Test]
        public void GetWordCount_With_String_Input_Test()
        {
            var result = "My name is Prasad Honrao".GetWordCount();
            Assert.AreEqual(5, result);
        }

        [Test]
        public void GetWordCount_With_String_With_Special_Symbol_Input_Test()
        {
            var result = "@#@#@# My @name @is @Prasad @Honrao @#@#@#".GetWordCount();
            Assert.AreEqual(7, result);
        }

        [Test]
        public void GetWordCount_Blank_String_Test()
        {
            var result = "".GetWordCount();
            Assert.AreEqual(0, result);
        }

        [Test]
        public void GetWordCount_Long_Blank_String_Test()
        {
            var result = "        ".GetWordCount();
            Assert.AreEqual(0, result);
        }
        
        #endregion

        #region IsLower

        [Test]
        public void IsLower_LowerCase_String_Input_Test()
        {
            var result = "twinkle twinkle little star".IsLower();
            Assert.AreEqual(true, result);
        }
        
        [Test]
        public void IsLower_MixedCase_String_Input_Test()
        {
            var result = "Twinkle Twinkle Little Star".IsLower();
            Assert.AreEqual(false, result);
        }

        [Test]
        public void IsLower_Integer_String_Input_Test()
        {
            var result = "1234567890".IsLower();
            Assert.AreEqual(false, result);
        }

        [Test]
        public void IsLower_Special_Symbol_String_Input_Test()
        {
            var result = "!@#$%^&*()".IsLower();
            Assert.AreEqual(false, result);
        }

        #endregion

        #region IsUpper

        [Test]
        public void IsUpper_UpperCase_String_Input_Test()
        {
            var result = "TWINKLE TWINKLE LITTLE STAR".IsUpper();
            Assert.AreEqual(true, result);
        }

        [Test]
        public void IsUpper_MixedCase_String_Input_Test()
        {
            var result = "Twinkle Twinkle Little Star".IsUpper();
            Assert.AreEqual(false, result);
        }

        [Test]
        public void IsUpper_Integer_String_Input_Test()
        {
            var result = "1234567890".IsUpper();
            Assert.AreEqual(false, result);
        }

        [Test]
        public void IsUpper_Special_Symbol_String_Input_Test()
        {
            var result = "!@#$%^&*()".IsUpper();
            Assert.AreEqual(false, result);
        }

        #endregion

        #region IsEmail

        [Test]
        public void IsEmail_Valid_Input_1_Test()
        {
            var result = "Honrao.Prasad@Gmail.com".IsEmail();
            Assert.AreEqual(true, result);
        }

        [Test]
        public void IsEmail_Valid_Input_2_Test()
        {
            var result = "d.j@server1.proseware.com".IsEmail();
            Assert.AreEqual(true, result);
        }

        [Test]
        public void IsEmail_Valid_Input_3_Test()
        {
            var result = "jones@ms1.proseware.com".IsEmail();
            Assert.AreEqual(true, result);
        }

        [Test]
        public void IsEmail_Valid_Input_4_Test()
        {
            var result = "j@proseware.com9".IsEmail();
            Assert.AreEqual(true, result);
        }

        [Test]
        public void IsEmail_Valid_Input_5_Test()
        {
            var result = "js#internal@proseware.com".IsEmail();
            Assert.AreEqual(true, result);
        }

        [Test]
        public void IsEmail_Valid_Input_6_Test()
        {
            var result = "j_9@[129.126.118.1]".IsEmail();
            Assert.AreEqual(true, result);
        }

        [Test]
        public void IsEmail_Invalid_String_Input_Test()
        {
            Assert.That(() => "Prasad Honrao".IsEmail(), Throws.TypeOf<FormatException>());
        }

        [Test]
        public void IsEmail_Number_As_String_Input_Test()
        {
            Assert.That(() => "1234567890".IsEmail(), Throws.TypeOf<FormatException>());
        }

        [Test]
        public void IsEmail_Empty_String_Input_Test()
        {
            Assert.That(() => "".IsEmail(), Throws.TypeOf<ArgumentNullException>());
        }

        #endregion

        #region IsNumeric

        [Test]
        public void IsNumeric_Valid_String_Input_Test()
        {
            var result = "1234567890".IsNumeric();
            Assert.AreEqual(true, result);
        }

        [Test]
        public void IsNumeric_String_With_Special_Symbol_Input_Test()
        {
            var result = "123456789@".IsNumeric();
            Assert.AreEqual(false, result);
        }

        [Test]
        public void IsNumeric_Special_Symbol_String_Input_Test()
        {
            var result = "@@".IsNumeric();
            Assert.AreEqual(false, result);
        }

        [Test]
        public void IsNumeric_Empty_String_Input_Test()
        {
            var result = string.Empty.IsNumeric();
            Assert.AreEqual(false, result);
        }

        #endregion

        #region IsPalindrome

        [Test]
        public void IsPalindrome_Valid_String_Input_Test()
        {
            var result = "ABBA".IsPalindrome();
            Assert.AreEqual(true, result);
        }

        [Test]
        public void IsPalindrome_Valid_Integer_String_Input_Test()
        {
            var result = "12321".IsPalindrome();
            Assert.AreEqual(true, result);
        }

        [Test]
        public void IsPalindrome_Invalid_Integer_String_Input_Test()
        {
            var result = "12345".IsPalindrome();
            Assert.AreEqual(false, result);
        }

        [Test]
        public void IsPalindrome_Invalid_String_Input_Test()
        {
            var result = "Prasad".IsPalindrome();
            Assert.AreEqual(false, result);
        }

        [Test]
        public void IsPalindrome_Empty_String_Input_Test()
        {
            var result = string.Empty.IsPalindrome();
            Assert.AreEqual(true, result);
        }

        #endregion

        #region RemoveFirst

        [Test]
        public void RemoveFirst_Empty_String_Test()
        {
            Assert.That(() => string.Empty.RemoveFirst(5), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void RemoveFirst_WhiteSpace_String_Test()
        {
            var result = "     ".RemoveFirst(2);
            Assert.AreEqual("   ", result);
        }

        [Test]
        public void RemoveFirst_Valid_String_Test()
        {
            var result = "ABCDE".RemoveFirst(2);
            Assert.AreEqual("CDE", result);
        }

        [Test]
        public void RemoveFirst_Integer_String_Test()
        {
            var result = "1234567890".RemoveFirst(5);
            Assert.AreEqual("67890", result);
        }

        [Test]
        public void RemoveFirst_Special_Symbol_String_Test()
        {
            var result = "!@#$%^&*()".RemoveFirst(0);
            Assert.AreEqual("!@#$%^&*()", result);
        }

        #endregion

        #region RemoveFirstCharacter

        [Test]
        public void RemoveFirstCharacter_Empty_String_Test()
        {
            Assert.That(() => string.Empty.RemoveFirstCharacter(), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void RemoveFirstCharacter_WhiteSpace_String_Test()
        {
            var result = "     ".RemoveFirstCharacter();
            Assert.AreEqual("    ", result);
        }

        [Test]
        public void RemoveFirstCharacter_Valid_String_Test()
        {
            var result = "ABCDE".RemoveFirstCharacter();
            Assert.AreEqual("BCDE", result);
        }

        [Test]
        public void RemoveFirstCharacter_Integer_String_Test()
        {
            var result = "1234567890".RemoveFirstCharacter();
            Assert.AreEqual("234567890", result);
        }

        [Test]
        public void RemoveFirstCharacter_Special_Symbol_String_Test()
        {
            var result = "!@#$%^&*()".RemoveFirstCharacter();
            Assert.AreEqual("@#$%^&*()", result);
        }

        #endregion

        #region RemoveLast

        [Test]
        public void RemoveLast_Empty_String_Test()
        {
            Assert.That(() => string.Empty.RemoveLast(5), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void RemoveLast_WhiteSpace_String_Test()
        {
            var result = "     ".RemoveLast(2);
            Assert.AreEqual("   ", result);
        }

        [Test]
        public void RemoveLast_Valid_String_Test()
        {
            var result = "ABCDE".RemoveLast(2);
            Assert.AreEqual("ABC", result);
        }

        [Test]
        public void RemoveLast_Integer_String_Test()
        {
            var result = "1234567890".RemoveLast(5);
            Assert.AreEqual("12345", result);
        }

        [Test]
        public void RemoveLast_Special_Symbol_String_Test()
        {
            var result = "!@#$%^&*()".RemoveLast(0);
            Assert.AreEqual("!@#$%^&*()", result);
        }

        #endregion

        #region RemoveLastCharacter

        [Test]
        public void RemoveLastCharacter_Empty_String_Test()
        {
            Assert.That(() => string.Empty.RemoveLastCharacter(), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void RemoveLastCharacter_WhiteSpace_String_Test()
        {
            var result = "     ".RemoveLastCharacter();
            Assert.AreEqual("    ", result);
        }

        [Test]
        public void RemoveLastCharacter_Valid_String_Test()
        {
            var result = "ABCDE".RemoveLastCharacter();
            Assert.AreEqual("ABCD", result);
        }

        [Test]
        public void RemoveLastCharacter_Integer_String_Test()
        {
            var result = "1234567890".RemoveLastCharacter();
            Assert.AreEqual("123456789", result);
        }

        [Test]
        public void RemoveLastCharacter_Special_Symbol_String_Test()
        {
            var result = "!@#$%^&*()".RemoveLastCharacter();
            Assert.AreEqual("!@#$%^&*(", result);
        }

        #endregion

        #region SwapCase

        [Test]
        public void SwapCase_String_Input_Test()
        {
            var result = "AaAaAa".SwapCase();
            Assert.AreEqual("aAaAaA", result);
        }

        [Test]
        public void SwapCase_UpperCase_String_Input_Test()
        {
            var result = "AAAAA".SwapCase();
            Assert.AreEqual("aaaaa", result);
        }

        [Test]
        public void SwapCase_LowerCase_String_Input_Test()
        {
            var result = "aaaaa".SwapCase();
            Assert.AreEqual("AAAAA", result);
        }

        [Test]
        public void SwapCase_Empty_String_Input_Test()
        {
            var result = string.Empty.SwapCase();
            Assert.AreEqual(string.Empty, result);
        }

        [Test]
        public void SwapCase_Alphanumeric_String_Input_Test()
        {
            var result = "pras@d".SwapCase();
            Assert.AreEqual("PRAS@D", result);
        }

        [Test]
        public void SwapCase_Integer_String_Input_Test()
        {
            var result = "1234567890".SwapCase();
            Assert.AreEqual("1234567890", result);
        }

        #endregion

        #region TrimAndReduce

        [Test]
        public void TrimAndReduce_String_With_Spaces_Input_Test()
        {
            var result = "  I'm    wearing the   cheese.  It isn't wearing me!   ".TrimAndReduce();
            Assert.AreEqual("I'm wearing the cheese. It isn't wearing me!", result);
        }

        [Test]
        public void TrimAndReduce_Empty_String_Input_Test()
        {
            var result = string.Empty.TrimAndReduce();
            Assert.AreEqual(string.Empty, result);
        }

        [Test]
        public void TrimAndReduce_String_With_No_Extra_Space_Test()
        {
            var result = "Hello World".TrimAndReduce();
            Assert.AreEqual("Hello World", result);
        }

        #endregion

        #region ToInt

        [Test]
        public void ToInt_Valid_String_To_Int_Test()
        {
            var input = "100".ToInt();
            Assert.IsTrue(input == 100);
        }

        [Test]
        public void ToInt_Invalid_String_To_Int_Test()
        {
            var input = "AAA".ToInt();
            Assert.IsTrue(input == 0);
        }

        [Test]
        public void ToInt_Empty_String_To_Int_Test()
        {
            var input = string.Empty.ToInt();
            Assert.IsTrue(input == 0);
        }

        [Test]
        public void ToInt_Special_Symbol_To_Int_Test()
        {
            var input = "!@#$%^".ToInt();
            Assert.IsTrue(input == 0);
        }

        #endregion

        #region ToTitleCase

        [Test]
        public void ToTitleCase_Upper_Case_String_Input_Test()
        {
            var output = "WAR AND PEACE".ToTitleCase();
            Assert.AreEqual("War And Peace", output);
        }

        [Test]
        public void ToTitleCase_Lower_Case_String_Input_Test()
        {
            var output = "war and peace".ToTitleCase();
            Assert.AreEqual("War And Peace", output);
        }

        [Test]
        public void ToTitleCase_MixCase_String_Input_Test()
        {
            var output = "WAR AND a PEACE".ToTitleCase();
            Assert.AreEqual("War And A Peace", output);
        }

        [Test]
        public void ToTitleCase_German_String_Input_Test()
        {
            var output = "Per anhalter durch die Galaxis".ToTitleCase();
            Assert.AreEqual("Per Anhalter Durch Die Galaxis", output);
        }

        [Test]
        public void ToTitleCase_Empty_String_Input_Test()
        {
            var output = "".ToTitleCase();
            Assert.AreEqual("", output);
        }

        [Test]
        public void ToTitleCase_Number_String_Input_Test()
        {
            var output = "1234567890".ToTitleCase();
            Assert.AreEqual("1234567890", output);
        }

        [Test]
        public void ToTitleCase_Number_With_Space_String_Input_Test()
        {
            var output = "123 456 7890".ToTitleCase();
            Assert.AreEqual("123 456 7890", output);
        }

        [Test]
        public void ToTitleCase_String_Integer_Input_Test()
        {
            var output = "My favorite number is 25.".ToTitleCase();
            Assert.AreEqual("My Favorite Number Is 25.", output);
        }

        [Test]
        public void ToTitleCase_Special_Symbol_Input_Test()
        {
            var output = "234 k3l2 *43 fun".ToTitleCase();
            Assert.AreEqual("234 K3l2 *43 Fun", output);
        }

        [Test]
        public void ToTitleCase_Apostrophes_Input_Test()
        {
            var output = "He's an engineer, isn't he?".ToTitleCase();
            Assert.AreEqual("He's An Engineer, Isn't He?", output);
        }

        [Test]
        public void ToTitleCase_Trailing_Space_Input_Test()
        {
            var output = "how many more test cases??       ".ToTitleCase();
            Assert.AreEqual("How Many More Test Cases??       ", output);
        }

        [Test]
        public void ToTitleCase_Leading_Space_Input_Test()
        {
            var output = "     how many more test cases??".ToTitleCase();
            Assert.AreEqual("     How Many More Test Cases??", output);
        }

        #endregion
    }
}
