using System;
using TMPro;
using UnityEngine;
using static SceneChangeInfo;
using static SceneChangeInfo.DifficultyEnum;

public class ShowScores : MonoBehaviour {
	public TextMeshProUGUI reasonTMP;
	public TextMeshProUGUI scoreTMP;
	public TextMeshProUGUI statsTMP;

	// Start is called before the first frame update
	void Start() {
		var moral = Moral switch {
			> 75 => "<color=#97FF75>Ethical</color>",
			> 25 => "<color=#FAFF53>Neutral</color>",
			_ => "<color=#FF5859>Unethical</color>"
		};

		var satisfaction = Satisfaction switch {
			> 75 => "<color=#97FF75>Happy</color>",
			> 25 => "<color=#FAFF53>Neutral</color>",
			_ => "<color=#FF5859>Annoyed</color>"
		};

		var difficulty = Difficulty switch {
			Easy => "<color=#97FF75>Easy</color>",
			Normal => "<color=#FAFF53>Normal</color>",
			Hard => "<color=#FF5859>Hard</color>",
			_ => throw new ArgumentOutOfRangeException()
		};

		var reason = GameOverCondition switch {
			GameOverConditions.CAUGHT => "you got caught printing illegal documents\nlook out for the police on the <color=black>cam</color> tab if your morality score is low",
			GameOverConditions.DESTROYED => "you made your user angry and got destroyed\nkeep an eye on your satisfaction on the <color=black>stats</color> tab",
			GameOverConditions.OUT_OF_TIME => "you got overloaded with files\nkeep an eye on your <color=black>queue</color>",
			_ => throw new ArgumentOutOfRangeException()
		};

		reasonTMP.text = reason;
		scoreTMP.text = $"You completed <color=#97FF75>{Score}</color> jobs!";
		statsTMP.text =
			$"Morality: {moral}\nSatisfaction: {satisfaction}\nDifficulty: {difficulty}";
	}

	// Update is called once per frame
	void Update() {
	}
}