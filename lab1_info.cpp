//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "lab1_info.h"
#include "MainMenu.h"
#include "MainWindow.h"
#include "Projects.h"
#include "Elements.h"
#include "Value_tabl.h"
#include "AmperPCH1.h"
#include "Value_for_6.h"
#include "Answer.h"
#include "Menu.h"
#include "Lab.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"

Tlab_inf *lab_inf;

extern Battery B;
extern Reostat Reost;
extern Resistor *Res;
extern Amper A;
extern Volt *V;
extern Perekl P;
extern Lines Lns;

extern int type, l,r1,r2,r3,nlab, count;
extern float i,p,v,r12;
int kol_str;

//---------------------------------------------------------------------------
__fastcall Tlab_inf::Tlab_inf(TComponent* Owner)
	: TForm(Owner)
{
}
//---------------------------------------------------------------------------
void __fastcall Tlab_inf::FormActivate(TObject *Sender)
{
	Image1->Center=true;
	Image3->Center=true;
}
//---------------------------------------------------------------------------
void __fastcall Tlab_inf::Image3MouseEnter(TObject *Sender)
{
	Image2->Visible=true;
}
//---------------------------------------------------------------------------
void __fastcall Tlab_inf::Image3MouseLeave(TObject *Sender)
{
	Image2->Visible=false;
}
//---------------------------------------------------------------------------
void __fastcall Tlab_inf::Image1MouseEnter(TObject *Sender)
{
	Image4->Visible=true;
}
//---------------------------------------------------------------------------
void __fastcall Tlab_inf::Image1MouseLeave(TObject *Sender)
{
	Image4->Visible=false;
}
//---------------------------------------------------------------------------
void __fastcall Tlab_inf::Image3Click(TObject *Sender)
{
    FProjects->Close();
	type=1;
	kol_str=1;
	l=1;
	if(FProjects->memo!=NULL)
	{
		count=1;
		FProjects->memo->Lines->Add("������������ ������ �1");
		FProjects->memo->Lines->Add("����: ������������� ��� � ��������. ������ ����������� ����.");
		FProjects->memo->Lines->Add("����: ��������� ������� �������������� ������������� ��� ����������������� � ������������ ����������� �����������");
		FProjects->memo->Lines->Add("---------------------------------");
		FProjects->memo->Lines->Add("��� ����������: ����������������");
		FProjects->memo->Lines->Add("---------------------------------");
		FProjects->memo->Lines->Add("------------��� ������-----------");
	}

	FProjects->lab=new TMain(Main);
	FProjects->lab->Caption="������������ ������ �1 - ������������� ��� � ��������. ������ ����������� ����";
	lab_inf->Close();
	FProjects->lab->Show();

	TPanel *p1 = new TPanel(Main);
	p1->Parent = FProjects->lab;
	p1->Height = 85;
	p1->Width = 150;
	p1->Top = 640;
	p1->StyleElements >> seClient;
	p1->BevelOuter = bvNone;
	p1->Left = 15;
	p1->Color = 0x00FF7B00;

	TLabel *t1 = new TLabel(Main);
	t1->Parent = p1;
	t1->Top=10;
	t1->Left = 15;
	t1->ParentColor = false;
	t1->ParentFont = false;
	t1->StyleElements << seFont;
	t1->Font->Color = clBlack;
	t1->Caption = "R1";
	t1->Font->Size = 20;

	TLabel *t2 = new TLabel(Main);
	t2->Parent = p1;
	t2->Top=45;
	t2->Left = 15;
	t2->ParentColor = false;
	t2->ParentFont = false;
	t2->StyleElements << seFont;
	t2->Font->Color = clBlack;
	t2->Caption = "R2";
	t2->Font->Size = 20;

	t3 = new TLabel(Main);
	t3->Parent = p1;
	t3->Top=10;
	t3->Left = 70;
	t3->ParentColor = false;
	t3->ParentFont = false;
	t3->StyleElements << seFont;
	t3->Font->Color = clBlack;
	t3->Caption = "1 ��";
	t3->Font->Size = 20;

	t4 = new TLabel(Main);
	t4->Parent = p1;
	t4->Top=45;
	t4->Left = 70;
	t4->ParentColor = false;
	t4->ParentFont = false;
	t4->StyleElements << seFont;
	t4->Font->Color = clBlack;
	t4->Caption = "1 ��";
	t4->Font->Size = 20;

	TPanel *p2 = new TPanel(Main);
	p2->Parent = FProjects->lab;
	p2->Height = 85;
	p2->Width = 250;
	p2->Top = 640;
	p2->StyleElements >> seClient;
	p2->BevelOuter = bvNone;
	p2->Left = 180;
	p2->Color = 0x00FF7B00;

	TLabel *t5 = new TLabel(Main);
	t5->Parent = p2;
	t5->Left = 15;
	t5->ParentColor = false;
	t5->ParentFont = false;
	t5->StyleElements << seFont;
	t5->Font->Color = clBlack;
	t5->Caption = "R";
	t5->Font->Size = 50;

	TLabel *t6 = new TLabel(Main);
	t6->Parent = p2;
	t6->Top=54;
	t6->Left = 60;
	t6->ParentColor = false;
	t6->ParentFont = false;
	t6->StyleElements << seFont;
	t6->Font->Color = clBlack;
	t6->Caption = "�����";
	t6->Font->Size = 10;

	R = new TLabel(Main);
	R->Parent = p2;
	R->Top = 18;
	R->Left = 120;
	R->ParentColor = false;
	R->ParentFont = false;
	R->StyleElements << seFont;
	R->Font->Color = clBlack;
	R->Caption = "3 ��";
	R->Font->Size = 30;

	TPanel *p3 = new TPanel(Main);
	p3->Parent = FProjects->lab;
	p3->Height = 85;
	p3->Width = 235;
	p3->Top = 640;
	p3->StyleElements >> seClient;
	p3->BevelOuter = bvNone;
	p3->Left = 445;
	p3->Color = 0x00FF7B00;

	TLabel *t7 = new TLabel(Main);
	t7->Parent = p3;
	t7->Left = 20;
	t7->ParentColor = false;
	t7->ParentFont = false;
	t7->StyleElements << seFont;
	t7->Font->Color = clBlack;
	t7->Caption = "I";
	t7->Font->Size = 50;

	I = new TLabel(Main);
	I->Parent = p3;
	I->Top = 18;
	I->Left = 75;
	I->ParentColor = false;
	I->ParentFont = false;
	I->StyleElements << seFont;
	I->Font->Color = clBlack;
	I->Caption = "1,00 A";
	I->Font->Size = 30;

	TPanel *p4 = new TPanel(Main);
	p4->Parent = FProjects->lab;
	p4->Height = 85;
	p4->Width = 300;
	p4->Top = 640;
	p4->StyleElements >> seClient;
	p4->BevelOuter = bvNone;
	p4->Left = 695;
	p4->Color = 0x00FF7B00;

	TLabel *t8 = new TLabel(Main);
	t8->Parent = p4;
	t8->Left = 20;
	t8->ParentColor = false;
	t8->ParentFont = false;
	t8->StyleElements << seFont;
	t8->Font->Color = clBlack;
	t8->Caption = "U";
	t8->Font->Size = 50;

	TLabel *t9 = new TLabel(Main);
	t9->Parent = p4;
	t9->Top=54;
	t9->Left = 65;
	t9->ParentColor = false;
	t9->ParentFont = false;
	t9->StyleElements << seFont;
	t9->Font->Color = clBlack;
	t9->Caption = "�� ������.";
	t9->Font->Size = 10;

	U = new TLabel(Main);
	U->Parent = p4;
	U->Top = 18;
	U->Left = 140;
	U->ParentColor = false;
	U->ParentFont = false;
	U->StyleElements << seFont;
	U->Font->Color = clBlack;
	U->Caption = "1,00 �";
	U->Font->Size = 30;

	//�������
	B.create(230,200);
	//�������
	Reost.create(555,450);
	//��������
	Res[0].create(480,200);
	Res[1].create(630,200);
	//���������
	A.create(830,325);
	//���������
	V[0].create(565,50);
	//����
	P.create(340,450);
	P.active=false;

	FProjects->lab->Repaint();

	Lns.paint("r");

	FValue->Width=820;
	FValue->SG->Width=735;
	FValue->SG->Height=159;
	FValue->SG->ColCount=8;
	FValue->SG->RowCount=6;
	FValue->SG->Cells[1][0]="U, B";
	FValue->SG->Cells[2][0]="R1, ��";
	FValue->SG->Cells[3][0]="R2, ��";
	FValue->SG->Cells[4][0]="U R1,R2, �";
	FValue->SG->Cells[5][0]="I, �";
	FValue->SG->Cells[6][0]="R, ��";
	FValue->SG->Cells[7][0]="P, ��";

	for(int i=1;i<=FValue->SG->RowCount;i++)
	{
		for(int j=1;j<=FValue->SG->ColCount;j++)
		{
			FValue->SG->Cells[j][i]="";
		}
	}

	FProjects->lab->Show();
	Lns.paint("r");
}

void __fastcall Tlab_inf::Image1Click(TObject *Sender)
{
	FProjects->Close();
	type=2;
	kol_str=1;
	l=1;
	if(FProjects->memo!=NULL)
	{
		count=1;
		FProjects->memo->Lines->Add("������������ ������ �1");
		FProjects->memo->Lines->Add("����: ������������� ��� � ��������. ������ ����������� ����.");
		FProjects->memo->Lines->Add("����: ��������� ������� �������������� ������������� ��� ����������������� � ������������ ����������� �����������");
		FProjects->memo->Lines->Add("---------------------------------");
		FProjects->memo->Lines->Add("��� ����������: ������������");
		FProjects->memo->Lines->Add("---------------------------------");
		FProjects->memo->Lines->Add("------------��� ������-----------");
	}

	FProjects->lab=new TMain(Main);
	FProjects->lab->Caption="������������ ������ �1 - ������������� ��� � ��������. ������ ����������� ����";
	lab_inf->Close();

    TPanel *p1 = new TPanel(Main);
	p1->Parent = FProjects->lab;
	p1->Height = 85;
	p1->Width = 110;
	p1->Top = 640;
	p1->StyleElements >> seClient;
	p1->BevelOuter = bvNone;
	p1->Left = 15;
	p1->Color = 0x00FF7B00;

	TLabel *t1 = new TLabel(Main);
	t1->Parent = p1;
	t1->Top=10;
	t1->Left = 15;
	t1->ParentColor = false;
	t1->ParentFont = false;
	t1->StyleElements << seFont;
	t1->Font->Color = clBlack;
	t1->Caption = "R1";
	t1->Font->Size = 14;

	TLabel *t2 = new TLabel(Main);
	t2->Parent = p1;
	t2->Top=32;
	t2->Left = 15;
	t2->ParentColor = false;
	t2->ParentFont = false;
	t2->StyleElements << seFont;
	t2->Font->Color = clBlack;
	t2->Caption = "R2";
	t2->Font->Size = 14;

	TLabel *t2_1 = new TLabel(Main);
	t2_1->Parent = p1;
	t2_1->Top=53;
	t2_1->Left = 15;
	t2_1->ParentColor = false;
	t2_1->ParentFont = false;
	t2_1->StyleElements << seFont;
	t2_1->Font->Color = clBlack;
	t2_1->Caption = "R3";
	t2_1->Font->Size = 14;

	t3 = new TLabel(Main);
	t3->Parent = p1;
	t3->Top=10;
	t3->Left = 50;
	t3->ParentColor = false;
	t3->ParentFont = false;
	t3->StyleElements << seFont;
	t3->Font->Color = clBlack;
	t3->Caption = "1 ��";
	t3->Font->Size = 14;

	t4 = new TLabel(Main);
	t4->Parent = p1;
	t4->Top=32;
	t4->Left = 50;
	t4->ParentColor = false;
	t4->ParentFont = false;
	t4->StyleElements << seFont;
	t4->Font->Color = clBlack;
	t4->Caption = "1 ��";
	t4->Font->Size = 14;

	t5 = new TLabel(Main);
	t5->Parent = p1;
	t5->Top=53;
	t5->Left = 50;
	t5->ParentColor = false;
	t5->ParentFont = false;
	t5->StyleElements << seFont;
	t5->Font->Color = clBlack;
	t5->Caption = "1 ��";
	t5->Font->Size = 14;

	TPanel *p2 = new TPanel(Main);
	p2->Parent = FProjects->lab;
	p2->Height = 85;
	p2->Width = 330;
	p2->Top = 640;
	p2->StyleElements >> seClient;
	p2->BevelOuter = bvNone;
	p2->Left = 140;
	p2->Color = 0x00FF7B00;

	TLabel *t5 = new TLabel(Main);
	t5->Parent = p2;
	t5->Left = 15;
	t5->ParentColor = false;
	t5->ParentFont = false;
	t5->StyleElements << seFont;
	t5->Font->Color = clBlack;
	t5->Caption = "R";
	t5->Font->Size = 50;

	TLabel *t6 = new TLabel(Main);
	t6->Parent = p2;
	t6->Top=54;
	t6->Left = 60;
	t6->ParentColor = false;
	t6->ParentFont = false;
	t6->StyleElements << seFont;
	t6->Font->Color = clBlack;
	t6->Caption = "�����";
	t6->Font->Size = 10;

	R = new TLabel(Main);
	R->Parent = p2;
	R->Top = 18;
	R->Left = 120;
	R->ParentColor = false;
	R->ParentFont = false;
	R->StyleElements << seFont;
	R->Font->Color = clBlack;
	R->Caption = "1,333 ��";
	R->Font->Size = 30;

	TPanel *p3 = new TPanel(Main);
	p3->Parent = FProjects->lab;
	p3->Height = 85;
	p3->Width = 230;
	p3->Top = 640;
	p3->StyleElements >> seClient;
	p3->BevelOuter = bvNone;
	p3->Left = 485;
	p3->Color = 0x00FF7B00;

	TLabel *t7 = new TLabel(Main);
	t7->Parent = p3;
	t7->Left = 20;
	t7->ParentColor = false;
	t7->ParentFont = false;
	t7->StyleElements << seFont;
	t7->Font->Color = clBlack;
	t7->Caption = "I";
	t7->Font->Size = 50;

	I = new TLabel(Main);
	I->Parent = p3;
	I->Top = 18;
	I->Left = 70;
	I->ParentColor = false;
	I->ParentFont = false;
	I->StyleElements << seFont;
	I->Font->Color = clBlack;
	I->Caption = "1,00 A";
	I->Font->Size = 30;

	TPanel *p4 = new TPanel(Main);
	p4->Parent = FProjects->lab;
	p4->Height = 85;
	p4->Width = 300;
	p4->Top = 640;
	p4->StyleElements >> seClient;
	p4->BevelOuter = bvNone;
	p4->Left = 730;
	p4->Color = 0x00FF7B00;

	TLabel *t8 = new TLabel(Main);
	t8->Parent = p4;
	t8->Left = 20;
	t8->ParentColor = false;
	t8->ParentFont = false;
	t8->StyleElements << seFont;
	t8->Font->Color = clBlack;
	t8->Caption = "U";
	t8->Font->Size = 50;

	TLabel *t9 = new TLabel(Main);
	t9->Parent = p4;
	t9->Top=54;
	t9->Left = 65;
	t9->ParentColor = false;
	t9->ParentFont = false;
	t9->StyleElements << seFont;
	t9->Font->Color = clBlack;
	t9->Caption = "�� ������.";
	t9->Font->Size = 10;

	U = new TLabel(Main);
	U->Parent = p4;
	U->Top = 18;
	U->Left = 140;
	U->ParentColor = false;
	U->ParentFont = false;
	U->StyleElements << seFont;
	U->Font->Color = clBlack;
	U->Caption = "1,00 �";
	U->Font->Size = 30;

	//�������
	B.create(205,200);
	//�������
	Reost.create(605,500);
	//��������
	Res[0].create(530,75);
	Res[1].create(530,200);
	Res[2].create(530,325);
	//���������
	A.create(780,325);
	//���������
	V[0].create(780,75);
	//����
	P.create(230,500);
	P.active=false;

	FProjects->lab->Repaint();

	FValue->SG->ColCount=9;
	FValue->SG->RowCount=6;
	FValue->Width=915;
	FValue->SG->Width=830;
	FValue->SG->Height=159;
	FValue->SG->Cells[1][0]="U, B";
	FValue->SG->Cells[2][0]="R1, ��";
	FValue->SG->Cells[3][0]="R2, ��";
	FValue->SG->Cells[4][0]="R3, ��";
	FValue->SG->Cells[5][0]="U R1,R2,R3, �";
	FValue->SG->Cells[6][0]="I, �";
	FValue->SG->Cells[7][0]="R, ��";
	FValue->SG->Cells[8][0]="P, ��";

    for(int i=1;i<=FValue->SG->RowCount;i++)
	{
		for(int j=1;j<=FValue->SG->ColCount;j++)
		{
			FValue->SG->Cells[j][i]="";
		}
	}

	FProjects->lab->Show();

	Lns.paint("r");
}
//---------------------------------------------------------------------------

void __fastcall Tlab_inf::Button1Click(TObject *Sender)
{
	lab_inf->Close();
	FProjects->Show();
}
//---------------------------------------------------------------------------

void __fastcall Tlab_inf::Image5MouseEnter(TObject *Sender)
{
	Image5->Picture->LoadFromFile("left_1.png");
}
//---------------------------------------------------------------------------

void __fastcall Tlab_inf::Image5MouseLeave(TObject *Sender)
{
    Image5->Picture->LoadFromFile("left.png");
}
//---------------------------------------------------------------------------

void __fastcall Tlab_inf::Image5Click(TObject *Sender)
{
	lab_inf->Close();
	FProjects->Show();
}
//---------------------------------------------------------------------------

