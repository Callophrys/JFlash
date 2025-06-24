# JFlash

## Formats:
| Abbrev | Format |
| ----- | ------ |
| 漢字 | Kanji |
| 英語 | English |
| R | Romaji |
| あ | Hirigana |
| カ| Katakana |


## Force in your head by testing the set with this sequence of format-to-formats.
| From | To |
| ---- | -- |
| 漢 | 英 |
| 漢 | R |
| あ | R |
| R | 英 |
| カ | R |
| R | 英 |
| 漢 | R |
| 漢 | 英 |

## Files with many, or any amount, questions can be converted to many subsets. Users can select any number of sets and/or subsets.

## The total questions chosen by a user can be converted to one last subset where the number of questions chosen by the user will be limit the test to just that many questions taken out of the users selection(s) at random.

## Mistakes can be reviewed at any time.

## Question Files (*.jpf)
- Multiple ==answers== of any format are support by separating with commas.
- Any single answer of a multiple-answer, in any format, can be suppressed from view by prefixing with the "#" character. This hides the prefixed answer from the initial prompting but the value is both used for evaluating the user's entry and will be shown in the question result. E.g. 五分,#5分 are both answers for "5 minutes" but #5分 gives away too much of the answer. By prefixing with "#" the value still be used to evaluate the user's answer and also be shown later with the result. All formats support this but it was implemented for displaying kanji as in the example mentioned.
- Romaji formatted answers with hyphens only need that one variant in the file. E.g. instead of all the values, e.g. "juugofun,juu-go-fun,juu go fun" just the value "juu-go-fun" is enough. "juu-go-fun" will internally evaluate the user's answer to "十五分" against any one of {"juugofun", "juu-go-fun", "juu go fun}.




