using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FripperController : MonoBehaviour
{
	//HingeJointコンポーネントを入れる
	private HingeJoint myHingeJoint;

	//初期の傾き
	private float defaultAngle = 20;
	//弾いた時の傾き
	private float flickAngle = -20;

	// Use this for initialization
	void Start()
	{
		//HingeJointコンポーネント取得
		this.myHingeJoint = GetComponent<HingeJoint>();

		//フリッパーの傾きを設定
		SetAngle(this.defaultAngle);
	}

	// Update is called once per frame
	void Update()
	{

		//左矢印キーを押した時左フリッパーを動かす //Aキーを押した時左フリッパーを動かす
		if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) && tag == "LeftFripperTag")
		{
			SetAngle(this.flickAngle);
		}

		//右矢印キーを押した時右フリッパーを動かす //Dキーを押した時右フリッパーを動かす
		if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) && tag == "RightFripperTag")
		{
			SetAngle(this.flickAngle);
		}

		//Sキーまたは下矢印キーを押した時は同時
		if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
		{
			SetAngle(this.flickAngle);
		}

		//矢印キー離された時フリッパーを元に戻す
		if ((Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A)) && tag == "LeftFripperTag")
		{
			SetAngle(this.defaultAngle);
		}

		if ((Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D)) && tag == "RightFripperTag")
		{
			SetAngle(this.defaultAngle);
		}

		if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
		{
			SetAngle(this.defaultAngle);
		}

		// タッチしている指の数を表示
		//GameObject.Find("TouchCount").GetComponent<Text>().text = "Input.touchCount :" + Input.touchCount;

		// タッチした指の数（一本指だけ）
		if (Input.touchCount == 1)
		{
			// 一本指
			Touch touch = Input.GetTouch(0);

			// 座標xがスクリーンの2分の1以上の場合
			if (touch.position.x <= Screen.width / 2)
			{
				// 左フリッパーが動く
				if (touch.phase == TouchPhase.Began && tag == "LeftFripperTag")
				{
					SetAngle(this.flickAngle);
				}
				if (touch.phase == TouchPhase.Ended && tag == "LeftFripperTag")
				{
					SetAngle(this.defaultAngle);
				}
			}
			else
			{
				// 右フリッパーが動く
				if (touch.phase == TouchPhase.Began && tag == "RightFripperTag")
				{
					SetAngle(this.flickAngle);
				}
				if (touch.phase == TouchPhase.Ended && tag == "RightFripperTag")
				{
					SetAngle(this.defaultAngle);
				}
			}
		}
		// タッチした指の数（二本指以上）
		else if (Input.touchCount > 1)
		{
			// タッチ変数
			Touch touch;

			// 一本目の指
			touch = Input.GetTouch(0);

			// 座標xがスクリーンの2分の1以上の場合
			if (touch.position.x <= Screen.width / 2)
			{
				// 左フリッパーが動く
				if (touch.phase == TouchPhase.Began && tag == "LeftFripperTag")
				{
					SetAngle(this.flickAngle);
				}
				if (touch.phase == TouchPhase.Ended && tag == "LeftFripperTag")
				{
					SetAngle(this.defaultAngle);
				}
			}
			else
			{
				// 右フリッパーが動く
				if (touch.phase == TouchPhase.Began && tag == "RightFripperTag")
				{
					SetAngle(this.flickAngle);
				}
				if (touch.phase == TouchPhase.Ended && tag == "RightFripperTag")
				{
					SetAngle(this.defaultAngle);
				}
			}

			// 二本目の指
			touch = Input.GetTouch(1);

			// 座標xがスクリーンの2分の1以上の場合
			if (touch.position.x <= Screen.width / 2)
			{
				// 左フリッパーが動く
				if (touch.phase == TouchPhase.Began && tag == "LeftFripperTag")
				{
					SetAngle(this.flickAngle);
				}
				if (touch.phase == TouchPhase.Ended && tag == "LeftFripperTag")
				{
					SetAngle(this.defaultAngle);
				}
			}
			else
			{
				// 右フリッパーが動く
				if (touch.phase == TouchPhase.Began && tag == "RightFripperTag")
				{
					SetAngle(this.flickAngle);
				}
				if (touch.phase == TouchPhase.Ended && tag == "RightFripperTag")
				{
					SetAngle(this.defaultAngle);
				}
			}
		}
	}



	//フリッパーの傾きを設定
	public void SetAngle(float angle)
	{
		JointSpring jointSpr = this.myHingeJoint.spring;
		jointSpr.targetPosition = angle;
		this.myHingeJoint.spring = jointSpr;
	}
}