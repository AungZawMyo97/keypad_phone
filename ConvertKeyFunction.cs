using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyPadConsole_CodeTest
{
	public class ConvertKeyFunction
	{
		public string ConvertInput(string input)
		{
			StringBuilder result = new StringBuilder();
			char lastChar = '\0';
			int pressCount = 0;

			for (int i = 0; i < input.Length; i++)
			{
				char ch = input[i];

				if (ch == '#')
				{
					break;
				}
				else if (ch == '*')
				{
					if (result.Length > 0)
					{
						result.Length -= 1;
					}
					pressCount = 0;
					lastChar = '\0';
				}
				else if (ch == ' ')
				{
					pressCount = 0;
					lastChar = '\0';
				}
				else if (KeyMappingModel.KeyMappings.ContainsKey(ch))
				{
					if (ch == lastChar)
					{
						pressCount++;
					}
					else
					{
						pressCount = 1;
						lastChar = ch;
					}

					string letters = KeyMappingModel.KeyMappings[ch];
					char letter = letters[(pressCount - 1) % letters.Length];

					if (i + 1 < input.Length && input[i + 1] != ch)
					{
						result.Append(letter);
					}
				}
			}

			return result.ToString();
		}
	}
}
