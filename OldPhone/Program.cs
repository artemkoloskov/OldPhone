using System;
using System.Collections.Generic;
using System.Linq;

namespace OldPhone
{
	class Program
	{
		private static readonly Dictionary<char, string> PadKeys = new()
		{
			{ '1', "&'(" },
			{ '2', "abc" },
			{ '3', "def" },
			{ '4', "ghi" },
			{ '5', "jkl" },
			{ '6', "mno" },
			{ '7', "pqrs" },
			{ '8', "tuv" },
			{ '9', "wxyz" },
			{ '0', " " },
			{ '*', "<" },
			{ '#', ">" },
		};

		static void Main()
		{
			Console.WriteLine(OldPhonePad("33#"));
			Console.WriteLine(OldPhonePad("227*#"));
			Console.WriteLine(OldPhonePad("4433555 555666#"));
			Console.WriteLine(OldPhonePad("8 88777444666*664#"));
			Console.WriteLine(OldPhonePad("4433555 55566606644422233086660633 338666*0999666880442888330206644422233032999#"));
		}

		private static string OldPhonePad(string input)
		{
			string result = "";
			char selectedLetter = '.';
			char previousKey = '.';

			foreach (char key in input)
			{
				if (key != previousKey)
				{
					result += selectedLetter == '.' ? "" : selectedLetter;
				}

				switch (key)
				{
					case '#':
						return result;

					case '*':
						selectedLetter = '.';
						result = result[0..^1];
						break;

					case ' ':
						selectedLetter = '.';
						break;

					default:
						if (key != previousKey)
						{
							selectedLetter = PadKeys[key].FirstOrDefault();
						}
						else
						{
							string keySequence = PadKeys[key];

							selectedLetter = keySequence[keySequence.IndexOf(selectedLetter) + 1];
						}

						break;
				}

				previousKey = key;
			}

			return result;
		}
	}
}
