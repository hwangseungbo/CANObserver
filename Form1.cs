using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Media;
using System.Threading;
using System.Windows.Forms;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Threading.Tasks;

namespace CANObserver
{
    public partial class Form1 : Form
    {
        Process[] Proc = Process.GetProcesses();
        private object lockObject = new object();   // lock문에 사용될 객체

        Queue<String> que = new Queue<String>();
        Thread thread;
        bool onlyone = true;
        int RdataNum = 0;

        string ecuData;
        string ecuData2;
        string ecuSubData;
        string ecuSubData2;

        public Form1()
        {
            InitializeComponent();

            //this.Size = new Size(861, 549);
            this.MaximizeBox = false;
            this.KeyPreview = true;
            //this.KeyDown += new KeyEventHandler(Form1_KeyDown);   // 키다운 이벤트 핸들러추가시 단축키 이벤트가 두번 발생하게되므로 주석처리.


            // PGN 61443
            string[] source = new string[10];
            source[0] = "61443";    // PGN
            source[1] = "558";    // SPN
            source[2] = "가속 페달 1 저속 유휴 스위치";    // Description
            source[3] = "2b";    // Size
            source[4] = "1.1";    // Start
            source[5] = "4 states/2 bit, 0 offset";    // Resoulution
            source[6] = "0 to 3";    // DataRange
            source[7] = "Measured";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "00-저속 공회전 상태가 아님, 01-저속 공회전 상태, 10-에러, 11-Not available";  // 비고
            ListViewItem i0 = new ListViewItem(source);
            listView1.Items.Add(i0);
            source[1] = "559";    // SPN
            source[2] = "가속 페달 킥다운 스위치";    // Description
            source[3] = "2b";    // Size
            source[4] = "1.3";    // Start
            source[5] = "4 states/2 bit, 0 offset";    // Resoulution
            source[6] = "0 to 3";    // DataRange
            source[7] = "Measured";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "00-킥다운 패시브, 01-킥다운 액티브, 10-에러, 11-Not available";  // 비고
            ListViewItem i1 = new ListViewItem(source);
            listView1.Items.Add(i1);
            source[1] = "1437";    // SPN
            source[2] = "도로 속도 제한 상태";    // Description
            source[3] = "2b";    // Size
            source[4] = "1.5";    // Start
            source[5] = "4 states/2 bit, 0 offset";    // Resoulution
            source[6] = "0 to 3";    // DataRange
            source[7] = "Status";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "00-Active, 01-Not Active, 10-에러, 11-Not available";  // 비고
            ListViewItem i2 = new ListViewItem(source);
            listView1.Items.Add(i2);
            source[1] = "2970";    // SPN
            source[2] = "가속 페달 2 저속 유휴 스위치";    // Description
            source[3] = "2b";    // Size
            source[4] = "1.7";    // Start
            source[5] = "4 states/2 bit, 0 offset";    // Resoulution
            source[6] = "0 to 3";    // DataRange
            source[7] = "Measured";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "00-저속 공회전 상태가 아님, 01-저속 공회전 상태, 10-에러, 11-Not available";  // 비고
            ListViewItem i3 = new ListViewItem(source);
            listView1.Items.Add(i3);
            source[1] = "91";    // SPN
            source[2] = "가속 페달 위치 1";    // Description
            source[3] = "1B";    // Size
            source[4] = "2";    // Start
            source[5] = "0.4 %/bit, 0 offset";    // Resoulution
            source[6] = "0 to 100 %";    // DataRange
            source[7] = "Measured";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "해양 애플리케이션에서 일반적으로 운전자의 스로틀 레버";  // 비고
            ListViewItem i4 = new ListViewItem(source);
            listView1.Items.Add(i4);
            source[1] = "92";    // SPN
            source[2] = "엔진 부하";    // Description
            source[3] = "1B";    // Size
            source[4] = "3";    // Start
            source[5] = "1 %/bit, 0 offset";    // Resoulution
            source[6] = "0 to 250 %";    // DataRange
            source[7] = "Status";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "Operational Range : 0 to 125 %";  // 비고
            ListViewItem i5 = new ListViewItem(source);
            listView1.Items.Add(i5);
            source[1] = "974";    // SPN
            source[2] = "원격 가속 페달 위치";    // Description
            source[3] = "1B";    // Size
            source[4] = "4";    // Start
            source[5] = "0.4 %/bit, 0 offset";    // Resoulution
            source[6] = "0 to 100 %";    // DataRange
            source[7] = "Measured";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "원격 아날로그 엔진 속도/토크 요청 입력 장치의 실제 위치 비율";  // 비고
            ListViewItem i6 = new ListViewItem(source);
            listView1.Items.Add(i6);
            source[1] = "29";    // SPN
            source[2] = "가속 페달 위치 2";    // Description
            source[3] = "1B";    // Size
            source[4] = "5";    // Start
            source[5] = "0.4 %/bit, 0 offset";    // Resoulution
            source[6] = "0 to 100 %";    // DataRange
            source[7] = "Measured";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "두 번째 아날로그 엔진 속도/토크 요청 입력 장치의 실제 위치 비율, 응용 프로그램에 가속기 컨트롤이 하나만 있는 경우 SPN 91을 사용합니다.";  // 비고
            ListViewItem i7 = new ListViewItem(source);
            listView1.Items.Add(i7);
            source[1] = "2979";    // SPN
            source[2] = "차량 가속도 제한 상태";    // Description
            source[3] = "2b";    // Size
            source[4] = "6.1";    // Start
            source[5] = "4 states/2 bit, 0 offset";    // Resoulution
            source[6] = "0 to 3";    // DataRange
            source[7] = "Status";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "00-리미트 비활성, 01-리미트 활성, 10-Reserved, 11-Not available, - 최대 차량 가속을 제한하는 데 사용되는 시스템의 상태(활성 또는 비활성)입니다.";  // 비고
            ListViewItem i8 = new ListViewItem(source);
            listView1.Items.Add(i8);
            source[1] = "5021";    // SPN
            source[2] = "순간 엔진 최대 출력 활성화 피드백";    // Description
            source[3] = "2b";    // Size
            source[4] = "6.3";    // Start
            source[5] = "4 states/2 bit, 0 offset";    // Resoulution
            source[6] = "0 to 3";    // DataRange
            source[7] = "Status";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "00-Disalbed, 01-Supported, 10-Reserved, 11-Don't care, - 일시적으로 엔진 최대 출력 활성화 요청 - 기능 지원 피드백";  // 비고
            ListViewItem i9 = new ListViewItem(source);
            listView1.Items.Add(i9);
            source[1] = "5399";    // SPN
            source[2] = "DPF 열 관리 활성";    // Description
            source[3] = "2b";    // Size
            source[4] = "6.5";    // Start
            source[5] = "4 states/2 bit, 0 offset";    // Resoulution
            source[6] = "0 to 3";    // DataRange
            source[7] = "Status";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "00-DPF 열 관리기 비활성, 01-DPF 열 관리기 활성, 10-Reserved, 11-Don't care, Thermal Management Active";  // 비고
            ListViewItem i10 = new ListViewItem(source);
            listView1.Items.Add(i10);
            source[1] = "5400";    // SPN
            source[2] = "SCR 열 관리 활성";    // Description
            source[3] = "2b";    // Size
            source[4] = "6.7";    // Start
            source[5] = "4 states/2 bit, 0 offset";    // Resoulution
            source[6] = "0 to 3";    // DataRange
            source[7] = "Status";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "00-SCR 열 관리기 비활성, 01-SCR 열 관리기 활성, 10-Reserved, 11-Don't care, Thermal Management Active";  // 비고
            ListViewItem i11 = new ListViewItem(source);
            listView1.Items.Add(i11);
            source[1] = "3357";    // SPN
            source[2] = "실제 최대 가용 엔진 - 퍼센트 토크";    // Description
            source[3] = "1B";    // Size
            source[4] = "7";    // Start
            source[5] = "0.4 %/bit, 0 offset";    // Resoulution
            source[6] = "0 to 100 %";    // DataRange
            source[7] = "Measured";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "엔진이 즉시 백분율로 전달할 수 있는 최대 토크량입니다.";  // 비고
            ListViewItem i12 = new ListViewItem(source);
            listView1.Items.Add(i12);
            source[1] = "5398";    // SPN
            source[2] = "예상 펌핑 - 퍼센트 토크";    // Description
            source[3] = "1B";    // Size
            source[4] = "8";    // Start
            source[5] = "1 %/bit, -125 % offset";    // Resoulution
            source[6] = "-125 to 125%";    // DataRange
            source[7] = "Measured";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "엔진 공조 시스템으로 인한 예상 토크 손실량을 나타내는 계산된 토크입니다.";  // 비고
            ListViewItem i13 = new ListViewItem(source);
            listView1.Items.Add(i13);



            // PGN 61444
            source[0] = "61444";    // PGN
            source[1] = "899";    // SPN
            source[2] = "엔진 토크 모드";    // Description
            source[3] = "4b";    // Size
            source[4] = "1.1";    // Start
            source[5] = "16 states/4 bit, 0 offset";    // Resoulution
            source[6] = "0 to 15";    // DataRange
            source[7] = "Measured";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "현재 토크를 생성, 제한 또는 제어하는 ​​엔진 토크 모드를 나타내는 상태 신호.";  // 비고
            ListViewItem i14 = new ListViewItem(source);
            listView1.Items.Add(i14);
            source[1] = "4154";    // SPN
            source[2] = "실제 엔진 - 퍼센트 토크 High Resolution";    // Description
            source[3] = "4b";    // Size
            source[4] = "1.5";    // Start
            source[5] = "0.125 %/bit, 0 offset";    // Resoulution
            source[6] = "0 to 0.875 %";    // DataRange
            source[7] = "Measured";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "SPN 513의 값과 더하면 실제 엔진토크가 나온다.(0000 = +0.000%, 0001 = +0.125%, ..., 0111 = +0.875%, 1000-1111 = Not available)";  // 비고
            ListViewItem i15 = new ListViewItem(source);
            listView1.Items.Add(i15);
            source[1] = "512";    // SPN
            source[2] = "운전자 요청 엔진 - 퍼센트 토크";    // Description
            source[3] = "1B";    // Size
            source[4] = "2";    // Start
            source[5] = "1 %/bit, -125 % offset";    // Resoulution
            source[6] = "-125 to 125 %";    // DataRange
            source[7] = "Measured";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "운전자가 요청한 엔진의 토크 출력입니다. Operational Range : 0 to 125 %";  // 비고
            ListViewItem i16 = new ListViewItem(source);
            listView1.Items.Add(i16);
            source[1] = "513";    // SPN
            source[2] = "실제 엔진 - 퍼센트 토크";    // Description
            source[3] = "1B";    // Size
            source[4] = "3";    // Start
            source[5] = "1 %/bit, -125 % offset";    // Resoulution
            source[6] = "-125 to 125 %";    // DataRange
            source[7] = "Measured";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "엔진의 계산된 출력 토크입니다.";  // 비고
            ListViewItem i17 = new ListViewItem(source);
            listView1.Items.Add(i17);
            source[1] = "190";    // SPN
            source[2] = "엔진 속도";    // Description
            source[3] = "2B";    // Size
            source[4] = "4-5";    // Start
            source[5] = "0.125 rpm/bit, 0 offset";    // Resoulution
            source[6] = "0 to 8031.875 rpm";    // DataRange
            source[7] = "Measured";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "최소 크랭크축 각도 720도에서 계산한 실제 엔진 속도를 실린더의 수로 나눈 실제 엔진 속도.";  // 비고
            ListViewItem i18 = new ListViewItem(source);
            listView1.Items.Add(i18);
            source[1] = "1483";    // SPN
            source[2] = "엔진 제어용 제어 장치의 소스 주소";    // Description
            source[3] = "1B";    // Size
            source[4] = "6";    // Start
            source[5] = "1 sourece address/bit, 0 offset";    // Resoulution
            source[6] = "0 to 255";    // DataRange
            source[7] = "Status";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "현재 엔진을 제어하는 ​​SAE J1939 장치의 소스 주소입니다.";  // 비고
            ListViewItem i19 = new ListViewItem(source);
            listView1.Items.Add(i19);
            source[1] = "1675";    // SPN
            source[2] = "엔진 스타터 모드";    // Description
            source[3] = "4b";    // Size
            source[4] = "7.1";    // Start
            source[5] = "16 states/4 bit, 0 offset";    // Resoulution
            source[6] = "0 to 15";    // DataRange
            source[7] = "Status";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "0000-Start not requested, 0001-시동 활성화, 기어가 맞물리지 않음, 0010-시동 활성화, 기어가 맞물림, 0011-Start finished; starter not active after having been actively engaged(after 50ms mode goes to 0000), 0100-이미 작동 중인 엔진으로 인해 스타터가 억제됨, 0101-시동 준비가 되지 않은 엔진으로 인해 시동이 억제됨(예열), 0110-구동계 연결 또는 기타 변속기 억제로 인해 시동기가 억제됨, 0111-활성 이모빌라이저로 인해 스타터가 억제됨, 1000-스타터 과열로 인해 스타터가 억제됨, 1001-1011   Reserved, 1100-스타터 억제 -이유를 알 수 없음, 1101-Error(레거시 구현에만 해당, 1110 사용), 1110-Error, 1111-Not available";  // 비고
            ListViewItem i20 = new ListViewItem(source);
            listView1.Items.Add(i20);
            source[1] = "2432";    // SPN
            source[2] = "엔진 수요 - 퍼센트 토크";    // Description
            source[3] = "1B";    // Size
            source[4] = "8";    // Start
            source[5] = "1 %/bit, -125 % offset";    // Resoulution
            source[6] = "-125 to 125 %";    // DataRange
            source[7] = "Measured";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "연기 제어, 소음 제어 및 낮은 제어를 포함한 모든 동적 내부 입력에 의한 엔진의 요청 토크 출력 그리고 고속 거버닝.";  // 비고
            ListViewItem i21 = new ListViewItem(source);
            listView1.Items.Add(i21);



            // PGN 61454
            source[0] = "61454";    // PGN
            source[1] = "3216";    // SPN
            source[2] = "후처리 1 NOx 흡기";    // Description
            source[3] = "2B";    // Size
            source[4] = "1-2";    // Start
            source[5] = "0.05 ppm/bit, -200 ppm offset";    // Resoulution
            source[6] = "-200 to 3012.75 ppm";    // DataRange
            source[7] = "Measured";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "후처리 시스템으로 들어가는 배기가스에서 후처리 흡기 시 NOx 센서에 의해 측정된 NO와 NO2의 총량.";  // 비고
            ListViewItem i22 = new ListViewItem(source);
            listView1.Items.Add(i22);
            source[1] = "3217";    // SPN
            source[2] = "후처리 1 O2 흡기";    // Description
            source[3] = "2B";    // Size
            source[4] = "3-4";    // Start
            source[5] = "0.000514 %/bit, -12 % offset";    // Resoulution
            source[6] = "-12 to 21 %";    // DataRange
            source[7] = "Measured";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "양수 값의 경우, 파라미터 값은 연소시 요구되는 필요량보다 초과되는 산소의 백분율, 음의 값의 경우, 매개변수는 센서에 의해 펌핑되는 산소의 양에 비례합니다.";  // 비고
            ListViewItem i23 = new ListViewItem(source);
            listView1.Items.Add(i23);
            source[1] = "3218";    // SPN
            source[2] = "후처리 1 흡기 가스 센서 전원 센서";    // Description
            source[3] = "2b";    // Size
            source[4] = "5.1";    // Start
            source[5] = "4 states/2 bit, 0 offset";    // Resoulution
            source[6] = "0 to 3";    // DataRange
            source[7] = "Status";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "00-Not in range, 01-In range, 10-에러, 11-Not available";  // 비고
            ListViewItem i24 = new ListViewItem(source);
            listView1.Items.Add(i24);
            source[1] = "3219";    // SPN
            source[2] = "후처리 1 온도에서의 흡기 가스 센서";    // Description
            source[3] = "2b";    // Size
            source[4] = "5.3";    // Start
            source[5] = "4 states/2 bit, 0 offset";    // Resoulution
            source[6] = "0 to 3";    // DataRange
            source[7] = "Status";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "00-Not in range, 01-In range, 10-에러, 11-Not available";  // 비고
            ListViewItem i25 = new ListViewItem(source);
            listView1.Items.Add(i25);
            source[1] = "3220";    // SPN
            source[2] = "후처리 1 흡기 NOx 안정 판독";    // Description
            source[3] = "2b";    // Size
            source[4] = "5.5";    // Start
            source[5] = "4 states/2 bit, 0 offset";    // Resoulution
            source[6] = "0 to 3";    // DataRange
            source[7] = "Status";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "00-Not stable, 01-Stable, 10-에러, 11-Not available";  // 비고
            ListViewItem i26 = new ListViewItem(source);
            listView1.Items.Add(i26);
            source[1] = "3221";    // SPN
            source[2] = "후처리 1 넓은 범위의 % O2 안정 판독";    // Description
            source[3] = "2b";    // Size
            source[4] = "5.5";    // Start
            source[5] = "4 states/2 bit, 0 offset";    // Resoulution
            source[6] = "0 to 3";    // DataRange
            source[7] = "Status";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "00-Not stable, 01-Stable, 10-에러, 11-Not available";  // 비고
            ListViewItem i27 = new ListViewItem(source);
            listView1.Items.Add(i27);
            source[1] = "3222";    // SPN
            source[2] = "후처리 1 흡기 가스 센서 히터 예비 FMI";    // Description
            source[3] = "5b";    // Size
            source[4] = "6.1";    // Start
            source[5] = "Binary, 0 offset";    // Resoulution
            source[6] = "0 to 31";    // DataRange
            source[7] = "Status";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "장애가 없으면 FMI 31이 전송됩니다";  // 비고
            ListViewItem i28 = new ListViewItem(source);
            listView1.Items.Add(i28);
            source[1] = "3223";    // SPN
            source[2] = "후처리 1 흡기 가스 센서 히터 제어";    // Description
            source[3] = "2b";    // Size
            source[4] = "6.1";    // Start
            source[5] = "4 states/2 bit, 0 offset";    // Resoulution
            source[6] = "0 to 3";    // DataRange
            source[7] = "Status";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "예열 과정에서 히터 상태를 나타냅니다. 00-자동, 01-예열2, 10-예열1, 11-히터 off";  // 비고
            ListViewItem i29 = new ListViewItem(source);
            listView1.Items.Add(i29);
            source[1] = "3224";    // SPN
            source[2] = "후처리 1 흡기 NOx 센서 예비 FMI";    // Description
            source[3] = "5b";    // Size
            source[4] = "7.1";    // Start
            source[5] = "Binary, 0 offset";    // Resoulution
            source[6] = "0 to 31";    // DataRange
            source[7] = "Status";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "장애가 없으면 FMI 31이 전송됩니다.";  // 비고
            ListViewItem i30 = new ListViewItem(source);
            listView1.Items.Add(i30);
            source[1] = "3225";    // SPN
            source[2] = "후처리 1 흡기 산소 센서 예비 FMI";    // Description
            source[3] = "5b";    // Size
            source[4] = "8.1";    // Start
            source[5] = "Binary, 0 offset";    // Resoulution
            source[6] = "0 to 31";    // DataRange
            source[7] = "Status";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "장애가 없으면 FMI 31이 전송됩니다.";  // 비고
            ListViewItem i31 = new ListViewItem(source);
            listView1.Items.Add(i31);



            // PGN 61455
            source[0] = "61455";    // PGN
            source[1] = "3226";    // SPN
            source[2] = "후처리 1 NOx 배기";    // Description
            source[3] = "2B";    // Size
            source[4] = "1-2";    // Start
            source[5] = "0.05 ppm/bit, -200 ppm offset";    // Resoulution
            source[6] = "-200 to 3012.75 ppm";    // DataRange
            source[7] = "Measured";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "배기구 내의 NOx 센서에 의해 후처리 시스템에서 배출되는 배기 가스에서 결합된 NO 및 NO2의 측정량.";  // 비고
            ListViewItem i32 = new ListViewItem(source);
            listView1.Items.Add(i32);
            source[1] = "3227";    // SPN
            source[2] = "후처리 1 O2 배기";    // Description
            source[3] = "2B";    // Size
            source[4] = "3-4";    // Start
            source[5] = "0.000514 %/bit, -12 % offset";    // Resoulution
            source[6] = "-12 to 21%";    // DataRange
            source[7] = "Measured";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "양수일 경우, 화학양론적 연소에 필요한 양을 초과하는 산소 백분율을, - 음수일 경우, 매개변수는 센서에 의해 펌핑되는 산소의 양에 비례합니다.";  // 비고
            ListViewItem i33 = new ListViewItem(source);
            listView1.Items.Add(i33);
            source[1] = "3228";    // SPN
            source[2] = "후처리 1 배기가스센서 전원상태";    // Description
            source[3] = "2b";    // Size
            source[4] = "5.1";    // Start
            source[5] = "4 states/2 bit, 0 offset";    // Resoulution
            source[6] = "0 to 3";    // DataRange
            source[7] = "Status";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "00-Not in range, 01-In range, 10-에러, 11-Not available";  // 비고
            ListViewItem i34 = new ListViewItem(source);
            listView1.Items.Add(i34);
            source[1] = "3229";    // SPN
            source[2] = "후처리 1 온도에서의 배기 가스 센서";    // Description
            source[3] = "2b";    // Size
            source[4] = "5.3";    // Start
            source[5] = "4 states/2 bit, 0 offset";    // Resoulution
            source[6] = "0 to 3";    // DataRange
            source[7] = "Status";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "00-Not in range, 01-In range, 10-에러, 11-Not available";  // 비고
            ListViewItem i35 = new ListViewItem(source);
            listView1.Items.Add(i35);
            source[1] = "3230";    // SPN
            source[2] = "후처리 1 배기 NOx 안정 판독값";    // Description
            source[3] = "2b";    // Size
            source[4] = "5.5";    // Start
            source[5] = "4 states/2 bit, 0 offset";    // Resoulution
            source[6] = "0 to 3";    // DataRange
            source[7] = "Status";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "00-안정적이지 않음, 01-안정적임, 10-에러, 11-Not available";  // 비고
            ListViewItem i36 = new ListViewItem(source);
            listView1.Items.Add(i36);
            source[1] = "3231";    // SPN
            source[2] = "후처리 1 넓은 범위 % O2 안정 판독값";    // Description
            source[3] = "2b";    // Size
            source[4] = "5.7";    // Start
            source[5] = "4 states/2 bit, 0 offset";    // Resoulution
            source[6] = "0 to 3";    // DataRange
            source[7] = "Status";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "00-안정적이지 않음, 01-안정적임, 10-에러, 11-Not available";  // 비고
            ListViewItem i37 = new ListViewItem(source);
            listView1.Items.Add(i37);
            source[1] = "3232";    // SPN
            source[2] = "후처리 1 배기가스 센서 히터 예비 FMI";    // Description
            source[3] = "5b";    // Size
            source[4] = "6.1";    // Start
            source[5] = "Binary, 0 offset";    // Resoulution
            source[6] = "0 to 31";    // DataRange
            source[7] = "Status";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "장애가 없으면 FMI 31이 전송됩니다.";  // 비고
            ListViewItem i38 = new ListViewItem(source);
            listView1.Items.Add(i38);
            source[1] = "3233";    // SPN
            source[2] = "후처리 1 배기가스 센서 히터 제어";    // Description
            source[3] = "2b";    // Size
            source[4] = "6.6";    // Start
            source[5] = "4 states/2 bit, 0 offset";    // Resoulution
            source[6] = "0 to 3";    // DataRange
            source[7] = "Status";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "00-자동, 01-예열2, 10-예열1, 11-Heater off";  // 비고
            ListViewItem i39 = new ListViewItem(source);
            listView1.Items.Add(i39);
            source[1] = "3234";    // SPN
            source[2] = "후처리 1 배기 NOx 센서 예비 FMI";    // Description
            source[3] = "5b";    // Size
            source[4] = "7.1";    // Start
            source[5] = "Binary, 0 offset";    // Resoulution
            source[6] = "0 to 31";    // DataRange
            source[7] = "Status";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "장애가 없으면 FMI 31이 전송됩니다. 다중 장애의 경우 가장 심각한 문제만 전달됩니다.";  // 비고
            ListViewItem i40 = new ListViewItem(source);
            listView1.Items.Add(i40);
            source[1] = "3235";    // SPN
            source[2] = "후처리 1 배기 산소센서 예비 FMI";    // Description
            source[3] = "5b";    // Size
            source[4] = "8.1";    // Start
            source[5] = "Binary, 0 offset";    // Resoulution
            source[6] = "0 to 31";    // DataRange
            source[7] = "Status";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "장애가 없으면 FMI 31이 전송됩니다. 다중 장애의 경우 가장 심각한 문제만 전달됩니다.";  // 비고
            ListViewItem i41 = new ListViewItem(source);
            listView1.Items.Add(i41);



            // PGN 61456
            source[0] = "61456";    // PGN
            source[1] = "3255";    // SPN
            source[2] = "후처리 2 NOx 흡기";    // Description
            source[3] = "2B";    // Size
            source[4] = "1-2";    // Start
            source[5] = "0.05 ppm/bit, -200 ppm offset";    // Resoulution
            source[6] = "-200 to 3012.75 ppm";    // DataRange
            source[7] = "Measured";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "후처리 시스템으로 들어가는 배기가스의 결합된 NO 및 NO2의 총 측정량.";  // 비고
            ListViewItem i42 = new ListViewItem(source);
            listView1.Items.Add(i42);
            source[1] = "3256";    // SPN
            source[2] = "후처리 2 O2 흡기";    // Description
            source[3] = "2B";    // Size
            source[4] = "3-4";    // Start
            source[5] = "0.000514 %/bit, -12 % offset";    // Resoulution
            source[6] = "-12 to 21 %";    // DataRange
            source[7] = "Measured";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "양수 값의 경우, 파라미터 값은 연소시 요구되는 필요량보다 초과되는 산소의 백분율, 음의 값의 경우, 매개변수는 센서에 의해 펌핑되는 산소의 양에 비례";  // 비고
            ListViewItem i43 = new ListViewItem(source);
            listView1.Items.Add(i43);
            source[1] = "3257";    // SPN
            source[2] = "후처리 2 흡기 가스 센서 전원 상태";    // Description
            source[3] = "2b";    // Size
            source[4] = "5.1";    // Start
            source[5] = "4 states/2 bit, 0 offset";    // Resoulution
            source[6] = "0 to 3";    // DataRange
            source[7] = "Status";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "00-Not in range, 01-In range, 10-에러, 11-Not available";  // 비고
            ListViewItem i44 = new ListViewItem(source);
            listView1.Items.Add(i44);
            source[1] = "3258";    // SPN
            source[2] = "후처리 2 온도에 따른 흡기 가스센서";    // Description
            source[3] = "2b";    // Size
            source[4] = "5.3";    // Start
            source[5] = "4 states/2 bit, 0 offset";    // Resoulution
            source[6] = "0 to 3";    // DataRange
            source[7] = "Status";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "00-Not in range, 01-In range, 10-에러, 11-Not available";  // 비고
            ListViewItem i45 = new ListViewItem(source);
            listView1.Items.Add(i45);
            source[1] = "3259";    // SPN
            source[2] = "후처리 2 NOx 안정 판독";    // Description
            source[3] = "2b";    // Size
            source[4] = "5.5";    // Start
            source[5] = "4 states/2 bit, 0 offset";    // Resoulution
            source[6] = "0 to 3";    // DataRange
            source[7] = "Status";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "00-Not Stable, 01-Stable, 10-에러, 11-Not available";  // 비고
            ListViewItem i46 = new ListViewItem(source);
            listView1.Items.Add(i46);
            source[1] = "3260";    // SPN
            source[2] = "후처리 2 넓은 범위 % O2 안정 판독";    // Description
            source[3] = "2b";    // Size
            source[4] = "5.7";    // Start
            source[5] = "4 states/2 bit, 0 offset";    // Resoulution
            source[6] = "0 to 3";    // DataRange
            source[7] = "Status";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "00-Not Stable, 01-Stable, 10-에러, 11-Not available";  // 비고
            ListViewItem i47 = new ListViewItem(source);
            listView1.Items.Add(i47);
            source[1] = "3261";    // SPN
            source[2] = "후처리 2 흡기 가스 센서 히터 예비 FMI";    // Description
            source[3] = "5b";    // Size
            source[4] = "6.1";    // Start
            source[5] = "Binary, 0 offset";    // Resoulution
            source[6] = "0 to 31";    // DataRange
            source[7] = "Status";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "장애가 없으면 FMI 31이 전송됩니다.";  // 비고
            ListViewItem i48 = new ListViewItem(source);
            listView1.Items.Add(i48);
            source[1] = "3262";    // SPN
            source[2] = "후처리 2 흡기 가스센서 히터 제어";    // Description
            source[3] = "2b";    // Size
            source[4] = "6.6";    // Start
            source[5] = "4 states/2 bit, 0 offset";    // Resoulution
            source[6] = "0 to 3";    // DataRange
            source[7] = "Status";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "예열 과정에서 히터 상태를 나타냅니다. 00-자동, 01-예열2, 10-예열1, 11-히터 off";  // 비고
            ListViewItem i49 = new ListViewItem(source);
            listView1.Items.Add(i49);
            source[1] = "3263";    // SPN
            source[2] = "후처리 2 흡기 NOx 센서 예비 FMI";    // Description
            source[3] = "5b";    // Size
            source[4] = "7.1";    // Start
            source[5] = "Binary, 0 offset";    // Resoulution
            source[6] = "0 to 31";    // DataRange
            source[7] = "Status";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "장애가 없으면 FMI 31이 전송됩니다.";  // 비고
            ListViewItem i50 = new ListViewItem(source);
            listView1.Items.Add(i50);
            source[1] = "3264";    // SPN
            source[2] = "후처리 2 흡기 산소 센서 예비 FMI";    // Description
            source[3] = "5b";    // Size
            source[4] = "8.1";    // Start
            source[5] = "Binary, 0 offset";    // Resoulution
            source[6] = "0 to 31";    // DataRange
            source[7] = "Status";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "장애가 없으면 FMI 31이 전송됩니다.";  // 비고
            ListViewItem i51 = new ListViewItem(source);
            listView1.Items.Add(i51);



            // PGN 61457
            source[0] = "61457";    // PGN
            source[1] = "3265";    // SPN
            source[2] = "후처리 2 NOx 배기";    // Description
            source[3] = "2B";    // Size
            source[4] = "1-2";    // Start
            source[5] = "0.05 ppm/bit, -200 ppm offset";    // Resoulution
            source[6] = "-200 to 3012.75 ppm";    // DataRange
            source[7] = "Measured";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "배기구 내의 NOx 센서에 의해 후처리 시스템에서 배출되는 배기 가스에서 결합된 NO 및 NO2의 측정량.";  // 비고
            ListViewItem i52 = new ListViewItem(source);
            listView1.Items.Add(i52);
            source[1] = "3266";    // SPN
            source[2] = "후처리 2 O2 배기";    // Description
            source[3] = "2B";    // Size
            source[4] = "3-4";    // Start
            source[5] = "0.000514 %/bit, -12 % offset";    // Resoulution
            source[6] = "-12 to 21%";    // DataRange
            source[7] = "Measured";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "양수일 경우, 화학양론적 연소에 필요한 양을 초과하는 산소 백분율을 나타냅니다. 음수일 경우, 매개변수는 센서에 의해 펌핑되는 산소의 양에 비례합니다.";  // 비고
            ListViewItem i53 = new ListViewItem(source);
            listView1.Items.Add(i53);
            source[1] = "3267";    // SPN
            source[2] = "후처리 2 배기 가스센서 전원 상태";    // Description
            source[3] = "2b";    // Size
            source[4] = "5.1";    // Start
            source[5] = "4 states/2 bit, 0 offset";    // Resoulution
            source[6] = "0 to 3";    // DataRange
            source[7] = "Status";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "00-범위 안에 있지 않음, 01-범위 안에 있음, 10-에러, 11-Not available";  // 비고
            ListViewItem i54 = new ListViewItem(source);
            listView1.Items.Add(i54);
            source[1] = "3268";    // SPN
            source[2] = "후처리 2 온도에 따른 배기 가스센서 ";    // Description
            source[3] = "2b";    // Size
            source[4] = "5.3";    // Start
            source[5] = "4 states/2 bit, 0 offset";    // Resoulution
            source[6] = "0 to 3";    // DataRange
            source[7] = "Status";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "00-범위 안에 있지 않음, 01-범위 안에 있음, 10-에러, 11-Not available";  // 비고
            ListViewItem i55 = new ListViewItem(source);
            listView1.Items.Add(i55);
            source[1] = "3269";    // SPN
            source[2] = "후처리 2 배기 NOx 안정 판독";    // Description
            source[3] = "2b";    // Size
            source[4] = "5.5";    // Start
            source[5] = "4 states/2 bit, 0 offset";    // Resoulution
            source[6] = "0 to 3";    // DataRange
            source[7] = "Status";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "00-안정적이지 않음, 01-안정적임, 10-에러, 11-Not available";  // 비고
            ListViewItem i56 = new ListViewItem(source);
            listView1.Items.Add(i56);
            source[1] = "3270";    // SPN
            source[2] = "후처리 2 넓은 범위의 % O2 안정 판독";    // Description
            source[3] = "2b";    // Size
            source[4] = "5.7";    // Start
            source[5] = "4 states/2 bit, 0 offset";    // Resoulution
            source[6] = "0 to 3";    // DataRange
            source[7] = "Status";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "00-안정적이지 않음, 01-안정적임, 10-에러, 11-Not available";  // 비고
            ListViewItem i57 = new ListViewItem(source);
            listView1.Items.Add(i57);
            source[1] = "3271";    // SPN
            source[2] = "후처리 2 배기가스 센서 히터 예비 FMI";    // Description
            source[3] = "5b";    // Size
            source[4] = "6.1";    // Start
            source[5] = "Binary, 0 offset";    // Resoulution
            source[6] = "0 to 31";    // DataRange
            source[7] = "Status";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "장애가 없으면 FMI 31이 전송됩니다.";  // 비고
            ListViewItem i58 = new ListViewItem(source);
            listView1.Items.Add(i58);
            source[1] = "3272";    // SPN
            source[2] = "후처리 2 배기가스 센서 히터 예비 FMI";    // Description
            source[3] = "2b";    // Size
            source[4] = "6.6";    // Start
            source[5] = "4 states/2 bit, 0 offset";    // Resoulution
            source[6] = "0 to 3";    // DataRange
            source[7] = "Status";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "예열 과정에서 히터 상태를 나타냅니다. 00-자동, 01-예열2, 10-예열1, 11-히터 off";  // 비고
            ListViewItem i59 = new ListViewItem(source);
            listView1.Items.Add(i59);
            source[1] = "3273";    // SPN
            source[2] = "후처리 2 배기 NOx 센서 예비 FMI";    // Description
            source[3] = "5b";    // Size
            source[4] = "7.1";    // Start
            source[5] = "Binary, 0 offset";    // Resoulution
            source[6] = "0 to 31";    // DataRange
            source[7] = "Status";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "장애가 없으면 FMI 31이 전송됩니다";  // 비고
            ListViewItem i60 = new ListViewItem(source);
            listView1.Items.Add(i60);
            source[1] = "3274";    // SPN
            source[2] = "후처리 2 배기 O2 센서 예비 FMI";    // Description
            source[3] = "5b";    // Size
            source[4] = "8.1";    // Start
            source[5] = "Binary, 0 offset";    // Resoulution
            source[6] = "0 to 31";    // DataRange
            source[7] = "Status";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "장애가 없으면 FMI 31이 전송됩니다";  // 비고
            ListViewItem i61 = new ListViewItem(source);
            listView1.Items.Add(i61);



            // PGN 61466
            source[0] = "61466";    // PGN
            source[1] = "3464";    // SPN
            source[2] = "엔진 스로틀 액츄에이터 1 제어 명령";    // Description
            source[3] = "2B";    // Size
            source[4] = "1-2";    // Start
            source[5] = "0.0025 %/bit, 0 offset";    // Resoulution
            source[6] = "0 to 160.6375 %";    // DataRange
            source[7] = "Status";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "0%는 완전히 닫힌 상태를 나타내고 100%는 완전히 열린 상태를 나타냅니다. Operational Range : 0 to 100 %";  // 비고
            ListViewItem i62 = new ListViewItem(source);
            listView1.Items.Add(i62);
            source[1] = "3465";    // SPN
            source[2] = "엔진 스로틀 액츄에이터 2 제어 명령";    // Description
            source[3] = "2B";    // Size
            source[4] = "3-4";    // Start
            source[5] = "0.0025 %/bit, 0 offset";    // Resoulution
            source[6] = "0 to 160.6375 %";    // DataRange
            source[7] = "Status";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "0%는 완전히 닫힌 상태를 나타내고 100%는 완전히 열린 상태를 나타냅니다. Operational Range : 0 to 100 %";  // 비고
            ListViewItem i63 = new ListViewItem(source);
            listView1.Items.Add(i63);
            source[1] = "633";    // SPN
            source[2] = "엔진 연료 액츄에이터 1 제어 명령";    // Description
            source[3] = "2B";    // Size
            source[4] = "5-6";    // Start
            source[5] = "0.0025 %/bit, 0 offset";    // Resoulution
            source[6] = "0 to 160.6375 %";    // DataRange
            source[7] = "Status";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "0%는 완전히 닫힌 상태를 나타내고 100%는 완전히 열린 상태를 나타냅니다. Operational Range : 0 to 100 %";  // 비고
            ListViewItem i64 = new ListViewItem(source);
            listView1.Items.Add(i64);
            source[1] = "1244";    // SPN
            source[2] = "엔진 연료 액츄에이터 2 제어 명령";    // Description
            source[3] = "2B";    // Size
            source[4] = "7-8";    // Start
            source[5] = "0.0025 %/bit, 0 offset";    // Resoulution
            source[6] = "0 to 160.6375 %";    // DataRange
            source[7] = "Status";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "0%는 완전히 닫힌 상태를 나타내고 100%는 완전히 열린 상태를 나타냅니다. Operational Range : 0 to 100 %";  // 비고
            ListViewItem i65 = new ListViewItem(source);
            listView1.Items.Add(i65);



            // PGN 65253
            source[0] = "65253";    // PGN
            source[1] = "247";    // SPN
            source[2] = "총 엔진 작동 시간";    // Description
            source[3] = "4B";    // Size
            source[4] = "1-4";    // Start
            source[5] = "0.05 hr/bit, 0 offset";    // Resoulution
            source[6] = "0 to 210,554,060,75 hr";    // DataRange
            source[7] = "Measured";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "엔진의 누적 작동 시간.";  // 비고
            ListViewItem i66 = new ListViewItem(source);
            listView1.Items.Add(i66);
            source[1] = "249";    // SPN
            source[2] = "엔진 총 회전수";    // Description
            source[3] = "4B";    // Size
            source[4] = "5-8";    // Start
            source[5] = "1000 r/bit, 0 offset";    // Resoulution
            source[6] = "0 to 4,211,081,215,000 r";    // DataRange
            source[7] = "Measured";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "엔진의 누적 회전 수.";  // 비고
            ListViewItem i67 = new ListViewItem(source);
            listView1.Items.Add(i67);



            // PGN 65262
            source[0] = "65262";    // PGN
            source[1] = "110";    // SPN
            source[2] = "엔진 냉각수 온도";    // Description
            source[3] = "1B";    // Size
            source[4] = "1";    // Start
            source[5] = "1 deg C/bit, -40 deg C offset";    // Resoulution
            source[6] = "-40 to 210 deg C";    // DataRange
            source[7] = "Measured";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "엔진 냉각 시스템에서 발견되는 액체의 온도.";  // 비고
            ListViewItem i68 = new ListViewItem(source);
            listView1.Items.Add(i68);
            source[1] = "174";    // SPN
            source[2] = "엔진 연료 온도 1";    // Description
            source[3] = "1B";    // Size
            source[4] = "2";    // Start
            source[5] = "1 deg C/bit, -40 deg C offset";    // Resoulution
            source[6] = "-40 to 210 deg C";    // DataRange
            source[7] = "Measured";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "첫 번째 연료 제어 시스템을 통과하는 연료(또는 가스)의 온도.";  // 비고
            ListViewItem i69 = new ListViewItem(source);
            listView1.Items.Add(i69);
            source[1] = "175";    // SPN
            source[2] = "엔진 오일 온도 1";    // Description
            source[3] = "2B";    // Size
            source[4] = "3-4";    // Start
            source[5] = "0.03125 deg C/bit, -273 deg C offset";    // Resoulution
            source[6] = "-273 to 1734.96875 deg C";    // DataRange
            source[7] = "Measured";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "엔진 윤활유의 온도.";  // 비고
            ListViewItem i70 = new ListViewItem(source);
            listView1.Items.Add(i70);
            source[1] = "176";    // SPN
            source[2] = "엔진 터보차저 오일 온도";    // Description
            source[3] = "2B";    // Size
            source[4] = "5-6";    // Start
            source[5] = "0.03125 deg C/bit, -273 deg C offset";    // Resoulution
            source[6] = "-273 to 1734.96875 deg C";    // DataRange
            source[7] = "Measured";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "터보차저 윤활유의 온도.";  // 비고
            ListViewItem i71 = new ListViewItem(source);
            listView1.Items.Add(i71);
            source[1] = "52";    // SPN
            source[2] = "엔진 인터쿨러 온도";    // Description
            source[3] = "1B";    // Size
            source[4] = "7";    // Start
            source[5] = "1 deg C/bit, -40 deg C offset";    // Resoulution
            source[6] = "-40 to 210 deg C";    // DataRange
            source[7] = "Measured";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "터보차저 윤활유의 온도.";  // 비고
            ListViewItem i72 = new ListViewItem(source);
            listView1.Items.Add(i72);
            source[1] = "1134";    // SPN
            source[2] = "엔진 인터쿨러 온도 조절기 개방";    // Description
            source[3] = "1B";    // Size
            source[4] = "8";    // Start
            source[5] = "0.4 %/bit, 0 offset";    // Resoulution
            source[6] = "0 to 100 %";    // DataRange
            source[7] = "Measured";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "값이 0%일 경우 온도조절기가 완전히 닫힌 상태를 의미하며 100%일 경우 온도조절기가 완전히 열린 상태를 의미합니다.";  // 비고
            ListViewItem i73 = new ListViewItem(source);
            listView1.Items.Add(i73);



            // PGN 65263
            source[0] = "65263";    // PGN
            source[1] = "94";    // SPN
            source[2] = "엔진 연료 공급 압력";    // Description
            source[3] = "1B";    // Size
            source[4] = "1";    // Start
            source[5] = "4 kPa/bit, 0 offet";    // Resoulution
            source[6] = "0 to 1000 kPa";    // DataRange
            source[7] = "Measured";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "공급 펌프에서 분사 펌프로 전달되는 시스템의 연료 게이지 압력.";  // 비고
            ListViewItem i74 = new ListViewItem(source);
            listView1.Items.Add(i74);
            source[1] = "22";    // SPN
            source[2] = "엔진 확장 크랭크케이스 블로바이 압력";    // Description
            source[3] = "1B";    // Size
            source[4] = "2";    // Start
            source[5] = "0.05 kPa/bit, 0 offset";    // Resoulution
            source[6] = "0 to 12.5 kPa";    // DataRange
            source[7] = "Measured";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "벤츄리가 있는 튜브를 통해 측정한 차동 크랭크케이스 블로바이 압력.(1264 사용되지 않음 – 폐기됨)";  // 비고
            ListViewItem i75 = new ListViewItem(source);
            listView1.Items.Add(i75);
            source[1] = "98";    // SPN
            source[2] = "엔진 오일 레벨";    // Description
            source[3] = "1B";    // Size
            source[4] = "3";    // Start
            source[5] = "0.4 %/bit, 0 offset";    // Resoulution
            source[6] = "0 to 100 %";    // DataRange
            source[7] = "Measured";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "최대 요구량에 대한 엔진 섬프 오일의 현재 부피 비율.";  // 비고
            ListViewItem i76 = new ListViewItem(source);
            listView1.Items.Add(i76);
            source[1] = "100";    // SPN
            source[2] = "엔진 오일 압력";    // Description
            source[3] = "1B";    // Size
            source[4] = "4";    // Start
            source[5] = "4 kPa/bit, 0 offset";    // Resoulution
            source[6] = "0 to 1000 kPa";    // DataRange
            source[7] = "Measured";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "오일 펌프에 의해 제공되는 엔진 윤활 시스템의 오일 게이지 압력.";  // 비고
            ListViewItem i77 = new ListViewItem(source);
            listView1.Items.Add(i77);
            source[1] = "101";    // SPN
            source[2] = "엔진 크랭크 케이스 압력";    // Description
            source[3] = "2B";    // Size
            source[4] = "5-6";    // Start
            source[5] = "1/128 kPa/bit, -250 kPa offset";    // Resoulution
            source[6] = "-250 kPa to 251.99 kPa";    // DataRange
            source[7] = "Measured";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "엔진 크랭크케이스 내부의 게이지 압력";  // 비고
            ListViewItem i78 = new ListViewItem(source);
            listView1.Items.Add(i78);
            source[1] = "109";    // SPN
            source[2] = "엔진 냉각수 압력";    // Description
            source[3] = "1B";    // Size
            source[4] = "7";    // Start
            source[5] = "2 kPa/bit, 0 offset";    // Resoulution
            source[6] = "0 to 500 kPa";    // DataRange
            source[7] = "Measured";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "엔진 냉각 시스템에서 발견되는 액체의 게이지 압력.";  // 비고
            ListViewItem i79 = new ListViewItem(source);
            listView1.Items.Add(i79);
            source[1] = "111";    // SPN
            source[2] = "엔진 냉각수 레벨";    // Description
            source[3] = "1B";    // Size
            source[4] = "8";    // Start
            source[5] = "0.4 %/bit, 0 offset";    // Resoulution
            source[6] = "0 to 100 %";    // DataRange
            source[7] = "Measured";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "총 냉각 시스템 부피에 대한 엔진 냉각 시스템에서 발견되는 액체 부피의 비율.";  // 비고
            ListViewItem i80 = new ListViewItem(source);
            listView1.Items.Add(i80);



            // PGN 65265
            source[0] = "65265";    // PGN
            source[1] = "69";    // SPN
            source[2] = "2단 속도 액슬 스위치";    // Description
            source[3] = "2b";    // Size
            source[4] = "1.1";    // Start
            source[5] = "4 states/2 bit, 0 offset";    // Resoulution
            source[6] = "0 to 3";    // DataRange
            source[7] = "Measured";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "현재 액슬 범위를 나타내는 스위치 신호. 00-저속범위, 01-고속범위, 10-에러, 11-Not available";  // 비고
            ListViewItem i81 = new ListViewItem(source);
            listView1.Items.Add(i81);
            source[1] = "70";    // SPN
            source[2] = "주차 브레이크 스위치";    // Description
            source[3] = "2b";    // Size
            source[4] = "1.3";    // Start
            source[5] = "4 states/2 bit, 0 offset";    // Resoulution
            source[6] = "0 to 3";    // DataRange
            source[7] = "Measured";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "00-주차브레이크 not set, 01-주차브레이크 set, 10-에러, 11-Not available";  // 비고
            ListViewItem i82 = new ListViewItem(source);
            listView1.Items.Add(i82);
            source[1] = "1633";    // SPN
            source[2] = "크루즈 컨트롤 일시정지 스위치";    // Description
            source[3] = "2b";    // Size
            source[4] = "1.5";    // Start
            source[5] = "4 states/2 bit, 0 offset";    // Resoulution
            source[6] = "0 to 3";    // DataRange
            source[7] = "Measured";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "00-Off, 01-On, 10-에러, 11-Take No Action";  // 비고
            ListViewItem i83 = new ListViewItem(source);
            listView1.Items.Add(i83);
            source[1] = "3807";    // SPN
            source[2] = "주차 브레이크 해제 금지 요청";    // Description
            source[3] = "2b";    // Size
            source[4] = "1.7";    // Start
            source[5] = "4 states/2 bit, 0 offset";    // Resoulution
            source[6] = "0 to 3";    // DataRange
            source[7] = "Status";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "00-주차브레이크 해제 금지 요청안됨, 01-주차브레이크 해제 금지 요청됨, 10-SAE reserved, 11-Unavailable   주차 브레이크 해제 금지 요청은 적용된 주차 브레이크가 계속 적용된 상태로 유지되기를 원한다는 신호입니다.";  // 비고
            ListViewItem i84 = new ListViewItem(source);
            listView1.Items.Add(i84);
            source[1] = "84";    // SPN
            source[2] = "휠 기반 차량 속도";    // Description
            source[3] = "2B";    // Size
            source[4] = "2-3";    // Start
            source[5] = "1/256 km/h per bit, 0 offset";    // Resoulution
            source[6] = "0 to 250.996 km/h";    // DataRange
            source[7] = "Measured";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "휠 또는 테일샤프트 속도에서 계산된 차량의 속도입니다.";  // 비고
            ListViewItem i85 = new ListViewItem(source);
            listView1.Items.Add(i85);
            source[1] = "595";    // SPN
            source[2] = "크루즈 컨트롤 액티브";    // Description
            source[3] = "2b";    // Size
            source[4] = "4.1";    // Start
            source[5] = "4 states/2 bit, 0 offset";    // Resoulution
            source[6] = "0 to 3";    // DataRange
            source[7] = "Measured";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "00-크루즈컨트롤 스위치 off, 01-크루즈컨트롤 스위치 on, 10-에러, 11-Not available";  // 비고
            ListViewItem i86 = new ListViewItem(source);
            listView1.Items.Add(i86);
            source[1] = "596";    // SPN
            source[2] = "크루즈 컨트롤 활성화 스위치";    // Description
            source[3] = "2b";    // Size
            source[4] = "4.3";    // Start
            source[5] = "4 states/2 bit, 0 offset";    // Resoulution
            source[6] = "0 to 3";    // DataRange
            source[7] = "Measured";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "크루즈 컨트롤 기능을 관리할 수 있음을 나타내는 스위치 신호입니다. 00-크루즈 컨트롤 불가능, 01-크루즈 컨트롤 가능, 10-에러, 11-Not available";  // 비고
            ListViewItem i87 = new ListViewItem(source);
            listView1.Items.Add(i87);
            source[1] = "597";    // SPN
            source[2] = "브레이크 스위치";    // Description
            source[3] = "2b";    // Size
            source[4] = "4.5";    // Start
            source[5] = "4 states/2 bit, 0 offset";    // Resoulution
            source[6] = "0 to 3";    // DataRange
            source[7] = "Measured";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "00-브레이크 페달에서 발을 땐 상태, 01-브레이크 페달 밟은 상태, 10-에러, 11-Not available";  // 비고
            ListViewItem i88 = new ListViewItem(source);
            listView1.Items.Add(i88);
            source[1] = "598";    // SPN
            source[2] = "클러치 스위치";    // Description
            source[3] = "2b";    // Size
            source[4] = "4.7";    // Start
            source[5] = "4 states/2 bit, 0 offset";    // Resoulution
            source[6] = "0 to 3";    // DataRange
            source[7] = "Measured";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "00-클러치 페달에서 발을 땐 상태, 01-클러치 페달 밟은 상태, 10-에러, 11-Not available";  // 비고
            ListViewItem i89 = new ListViewItem(source);
            listView1.Items.Add(i89);
            source[1] = "599";    // SPN
            source[2] = "크루즈 컨트롤 세트 스위치";    // Description
            source[3] = "2b";    // Size
            source[4] = "5.1";    // Start
            source[5] = "4 states/2 bit, 0 offset";    // Resoulution
            source[6] = "0 to 3";    // DataRange
            source[7] = "Measured";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "00-크루즈 컨트롤 액티베이터가 설정위치x, 01-크루즈 컨트롤 액티베이터가 설정위치o, 10-에러, 11-Not available";  // 비고
            ListViewItem i90 = new ListViewItem(source);
            listView1.Items.Add(i90);
            source[1] = "600";    // SPN
            source[2] = "크루즈 컨트롤 감속 스위치";    // Description
            source[3] = "2b";    // Size
            source[4] = "5.3";    // Start
            source[5] = "4 states/2 bit, 0 offset";    // Resoulution
            source[6] = "0 to 3";    // DataRange
            source[7] = "Measured";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "00-크루즈 컨트롤 액티베이터가 감속위치x, 01-크루즈 컨트롤 액티베이터가 감속위치o, 10-에러, 11-Not available";  // 비고
            ListViewItem i91 = new ListViewItem(source);
            listView1.Items.Add(i91);
            source[1] = "601";    // SPN
            source[2] = "크루즈 컨트롤 재개 스위치";    // Description
            source[3] = "2b";    // Size
            source[4] = "5.5";    // Start
            source[5] = "4 states/2 bit, 0 offset";    // Resoulution
            source[6] = "0 to 3";    // DataRange
            source[7] = "Measured";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "00-크루즈 컨트롤 액티베이터가 재개위치x, 01-크루즈 컨트롤 액티베이터가 재개위치o, 10-에러, 11-Not available";  // 비고
            ListViewItem i92 = new ListViewItem(source);
            listView1.Items.Add(i92);
            source[1] = "602";    // SPN
            source[2] = "크루즈 컨트롤 가속 스위치";    // Description
            source[3] = "2b";    // Size
            source[4] = "5.7";    // Start
            source[5] = "4 states/2 bit, 0 offset";    // Resoulution
            source[6] = "0 to 3";    // DataRange
            source[7] = "Measured";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "00-크루즈 컨트롤 액티베이터가 가속위치x, 01-크루즈 컨트롤 액티베이터가 가속위치o, 10-에러, 11-Not available";  // 비고
            ListViewItem i93 = new ListViewItem(source);
            listView1.Items.Add(i93);
            source[1] = "86";    // SPN
            source[2] = "크루즈 컨트롤 설정 속도";    // Description
            source[3] = "1B";    // Size
            source[4] = "6";    // Start
            source[5] = "1 km/h per bit, 0 offset";    // Resoulution
            source[6] = "0 to 250 km/h";    // DataRange
            source[7] = "Measured";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "속도 제어 시스템의 설정(선택) 속도 값입니다.";  // 비고
            ListViewItem i94 = new ListViewItem(source);
            listView1.Items.Add(i94);
            source[1] = "976";    // SPN
            source[2] = "PTO Governor State";    // Description
            source[3] = "5b";    // Size
            source[4] = "7.1";    // Start
            source[5] = "32 states/5 bit, 0 offset";    // Resoulution
            source[6] = "0 to 31";    // DataRange
            source[7] = "Status";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "동력인출장치 상태";  // 비고
            ListViewItem i95 = new ListViewItem(source);
            listView1.Items.Add(i95);
            source[1] = "527";    // SPN
            source[2] = "크루즈 컨트롤 스테이트";    // Description
            source[3] = "3b";    // Size
            source[4] = "7.6";    // Start
            source[5] = "8 states/3 bit, 0 offset";    // Resoulution
            source[6] = "0 to 7";    // DataRange
            source[7] = "Status";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "000-Off/Disabled, 001-Hold, 010-Accelerate, 011-Decelerate, 100-Rsume, 101-Set, 110-Accelerator Override, 111-Not available";  // 비고
            ListViewItem i96 = new ListViewItem(source);
            listView1.Items.Add(i96);
            source[1] = "968";    // SPN
            source[2] = "엔진 공회전 증가 스위치";    // Description
            source[3] = "2b";    // Size
            source[4] = "8.1";    // Start
            source[5] = "4 states/2 bit, 0 offset";    // Resoulution
            source[6] = "0 to 3";    // DataRange
            source[7] = "Measured";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "00-Off, 01-On, 10-에러, 11-Not available";  // 비고
            ListViewItem i97 = new ListViewItem(source);
            listView1.Items.Add(i97);
            source[1] = "967";    // SPN
            source[2] = "엔진 공회전 감소 스위치";    // Description
            source[3] = "2b";    // Size
            source[4] = "8.3";    // Start
            source[5] = "4 states/2 bit, 0 offset";    // Resoulution
            source[6] = "0 to 3";    // DataRange
            source[7] = "Measured";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "00-Off, 01-On, 10-에러, 11-Not available";  // 비고
            ListViewItem i98 = new ListViewItem(source);
            listView1.Items.Add(i98);
            source[1] = "966";    // SPN
            source[2] = "엔진 테스트 모드 스위치";    // Description
            source[3] = "2b";    // Size
            source[4] = "8.5";    // Start
            source[5] = "4 states/2 bit, 0 offset";    // Resoulution
            source[6] = "0 to 3";    // DataRange
            source[7] = "Measured";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "00-Off, 01-On, 10-에러, 11-Not available";  // 비고
            ListViewItem i99 = new ListViewItem(source);
            listView1.Items.Add(i99);
            source[1] = "1237";    // SPN
            source[2] = "엔진 셧다운 오버라이드 스위치";    // Description
            source[3] = "2b";    // Size
            source[4] = "8.7";    // Start
            source[5] = "4 states/2 bit, 0 offset";    // Resoulution
            source[6] = "0 to 3";    // DataRange
            source[7] = "Measured";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "00-Off, 01-On, 10-에러, 11-Not available";  // 비고
            ListViewItem i100 = new ListViewItem(source);
            listView1.Items.Add(i100);



            // PGN 65266
            source[0] = "65266";    // PGN
            source[1] = "183";    // SPN
            source[2] = "엔진 연료 비율";    // Description
            source[3] = "2B";    // Size
            source[4] = "1-2";    // Start
            source[5] = "0.05 L/h per bit, 0 offset";    // Resoulution
            source[6] = "0 to 3,212.75 L/h";    // DataRange
            source[7] = "Measured";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "단위 시간당 엔진이 소비하는 연료의 양.";  // 비고
            ListViewItem i101 = new ListViewItem(source);
            listView1.Items.Add(i101);
            source[1] = "184";    // SPN
            source[2] = "엔진 순간 연비";    // Description
            source[3] = "2B";    // Size
            source[4] = "3-4";    // Start
            source[5] = "1/512 km/L per bit, 0 offset";    // Resoulution
            source[6] = "0 to 125.5 km/L";    // DataRange
            source[7] = "Measured";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "현재 차량 속도에서 현재 연비.";  // 비고
            ListViewItem i102 = new ListViewItem(source);
            listView1.Items.Add(i102);
            source[1] = "185";    // SPN
            source[2] = "엔진 평균 연비";    // Description
            source[3] = "2B";    // Size
            source[4] = "5-6";    // Start
            source[5] = "1/512 km/L per bit, 0 offset";    // Resoulution
            source[6] = "0 to 125.5 km/L";    // DataRange
            source[7] = "Measured";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "관심 차량 운행 구간의 순간 연비 평균.";  // 비고
            ListViewItem i103 = new ListViewItem(source);
            listView1.Items.Add(i103);
            source[1] = "51";    // SPN
            source[2] = "엔진 스로틀 밸브 1 위치";    // Description
            source[3] = "1B";    // Size
            source[4] = "7";    // Start
            source[5] = "0.4 %/bit, 0 offset";    // Resoulution
            source[6] = "0 to 100 %";    // DataRange
            source[7] = "Measured";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "엔진으로 공급하는 것을 조절하는 데 사용되는 밸브의 위치입니다. 0%는 공급 없음 및 100%는 전체 공급입니다.";  // 비고
            ListViewItem i104 = new ListViewItem(source);
            listView1.Items.Add(i104);
            source[1] = "3673";    // SPN
            source[2] = "엔진 스로틀 밸브 2 위치";    // Description
            source[3] = "1B";    // Size
            source[4] = "8";    // Start
            source[5] = "0.4 %/bit, 0 offset";    // Resoulution
            source[6] = "0 to 100 %";    // DataRange
            source[7] = "Measured";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "엔진으로 공급하는 것을 조절하는 데 사용되는 밸브의 위치입니다. 0%는 공급 없음 및 100%는 전체 공급입니다.";  // 비고
            ListViewItem i105 = new ListViewItem(source);
            listView1.Items.Add(i105);



            // PGN 65270
            source[0] = "65270";    // PGN
            source[1] = "81";    // SPN
            source[2] = "엔진 디젤 미립자 필터 흡입 압력";    // Description
            source[3] = "1B";    // Size
            source[4] = "1";    // Start
            source[5] = "0.5 kPa/bit, 0 offset";    // Resoulution
            source[6] = "0 to 125 kPa";    // DataRange
            source[7] = "Measured";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "배기 스트림에 배치된 필터 매체에 입자 축적으로 인한 배기 배압.";  // 비고
            ListViewItem i106 = new ListViewItem(source);
            listView1.Items.Add(i106);
            source[1] = "102";    // SPN
            source[2] = "엔진 흡기 매니폴드 #1 압력";    // Description
            source[3] = "1B";    // Size
            source[4] = "2";    // Start
            source[5] = "2 kPa/bit, 0 offset";    // Resoulution
            source[6] = "0 to 500 kPa";    // DataRange
            source[7] = "Measured";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "흡기 매니폴드의 게이지의 측정 압력.";  // 비고
            ListViewItem i107 = new ListViewItem(source);
            listView1.Items.Add(i107);
            source[1] = "105";    // SPN
            source[2] = "엔진 흡기 매니폴드 1 온도";    // Description
            source[3] = "1B";    // Size
            source[4] = "3";    // Start
            source[5] = "1 deg C/bit, -40 deg C offset";    // Resoulution
            source[6] = "-40 to 210 deg C";    // DataRange
            source[7] = "Measured";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "엔진 공기 공급 시스템의 흡기 매니폴드에서 발견되는 연소 전 공기의 온도.";  // 비고
            ListViewItem i108 = new ListViewItem(source);
            listView1.Items.Add(i108);
            source[1] = "106";    // SPN
            source[2] = "엔진 공기 흡입구 압력";    // Description
            source[3] = "1B";    // Size
            source[4] = "4";    // Start
            source[5] = "2 kPa/bit, 0 offset";    // Resoulution
            source[6] = "0 to 500 kPa";    // DataRange
            source[7] = "Measured";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "흡기 매니폴드 또는 에어 박스에 대한 입력 포트의 절대 공기 압력.";  // 비고
            ListViewItem i109 = new ListViewItem(source);
            listView1.Items.Add(i109);
            source[1] = "107";    // SPN
            source[2] = "엔진 에어필터 1 압력차";    // Description
            source[3] = "1B";    // Size
            source[4] = "5";    // Start
            source[5] = "0.05 kPa/bit, 0 offset";    // Resoulution
            source[6] = "0 to 12.5 kPa";    // DataRange
            source[7] = "Measured";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "필터 내부의 축적되는 외부 고체 물질로 인해 필터 전체에서 측정되는 엔진 공기 시스템 압력의 변화.";  // 비고
            ListViewItem i110 = new ListViewItem(source);
            listView1.Items.Add(i110);
            source[1] = "173";    // SPN
            source[2] = "엔진 배기 가스 온도";    // Description
            source[3] = "2B";    // Size
            source[4] = "6-7";    // Start
            source[5] = "0.03125 deg C/bit, -273 deg C offset";    // Resoulution
            source[6] = "-273 to 1734.96875 deg C";    // DataRange
            source[7] = "Measured";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "엔진을 떠나는 연소 부산물의 온도.";  // 비고
            ListViewItem i111 = new ListViewItem(source);
            listView1.Items.Add(i111);
            source[1] = "112";    // SPN
            source[2] = "엔진 냉각수 필터 압력차";    // Description
            source[3] = "1B";    // Size
            source[4] = "8";    // Start
            source[5] = "0.5 kPa/bit, 0 offset";    // Resoulution
            source[6] = "0 to 125 kPa";    // DataRange
            source[7] = "Measured";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "필터 내부의 축적되는 고체 혹은 반고체 물질로 인해 필터 전체에서 측정되는 냉각수 압력의 변화.";  // 비고
            ListViewItem i112 = new ListViewItem(source);
            listView1.Items.Add(i112);



            // PGN 65271
            source[0] = "65271";    // PGN
            source[1] = "114";    // SPN
            source[2] = "순 배터리 전류";    // Description
            source[3] = "1B";    // Size
            source[4] = "1";    // Start
            source[5] = "1 A/bit, -125 A offset";    // Resoulution
            source[6] = "-125 to 125 A";    // DataRange
            source[7] = "Measured";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "배터리 또는 배터리로/밖으로 흐르는 전류의 순 흐름.";  // 비고
            ListViewItem i113 = new ListViewItem(source);
            listView1.Items.Add(i113);
            source[1] = "115";    // SPN
            source[2] = "교류 발전기 전류";    // Description
            source[3] = "1B";    // Size
            source[4] = "2";    // Start
            source[5] = "1 A/bit, 0 offset";    // Resoulution
            source[6] = "0 to 250 A";    // DataRange
            source[7] = "Measured";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "교류 발전기에서 흐르는 전류 측정.";  // 비고
            ListViewItem i114 = new ListViewItem(source);
            listView1.Items.Add(i114);
            source[1] = "167";    // SPN
            source[2] = "충전 시스템 전위(전압)";    // Description
            source[3] = "2B";    // Size
            source[4] = "3-4";    // Start
            source[5] = "0.05 V/bit, 0 offset";    // Resoulution
            source[6] = "0 to 3212.75 V";    // DataRange
            source[7] = "Measured";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "충전 시스템 출력에서 ​​측정된 전위입니다.";  // 비고
            ListViewItem i115 = new ListViewItem(source);
            listView1.Items.Add(i115);
            source[1] = "168";    // SPN
            source[2] = "배터리 전위 / 전원 입력 1";    // Description
            source[3] = "2B";    // Size
            source[4] = "5-6";    // Start
            source[5] = "0.05 V/bit, 0 offset";    // Resoulution
            source[6] = "0 to 3212.75 V";    // DataRange
            source[7] = "Measured";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "ECM/액추에이터 등의 입력에서 측정된 배터리 전위의 첫 번째 소스를 측정합니다.";  // 비고
            ListViewItem i116 = new ListViewItem(source);
            listView1.Items.Add(i116);
            source[1] = "158";    // SPN
            source[2] = "키 스위치 배터리 전위";    // Description
            source[3] = "2B";    // Size
            source[4] = "7-8";    // Start
            source[5] = "0.05 V/bit, 0 offset";    // Resoulution
            source[6] = "0 to 3212.75 V";    // DataRange
            source[7] = "Measured";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "키 스위치 또는 유사한 스위칭 장치를 통해 공급되는 전자 제어 장치의 입력에서 측정된 배터리 전위";  // 비고
            ListViewItem i117 = new ListViewItem(source);
            listView1.Items.Add(i117);



            // PGN 65276
            source[0] = "65276";    // PGN
            source[1] = "80";    // SPN
            source[2] = "와셔액 레벨";    // Description
            source[3] = "1B";    // Size
            source[4] = "1";    // Start
            source[5] = "0.4 %/bit, 0 offset";    // Resoulution
            source[6] = "0 to 100 %";    // DataRange
            source[7] = "Measured";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "앞유리 세척 시스템에 있는 액체 저장소의 총 용기 부피에 대한 액체 부피의 비율.";  // 비고
            ListViewItem i118 = new ListViewItem(source);
            listView1.Items.Add(i118);
            source[1] = "96";    // SPN
            source[2] = "연료 레벨 1";    // Description
            source[3] = "1B";    // Size
            source[4] = "2";    // Start
            source[5] = "0.4 %/bit, 0 offset";    // Resoulution
            source[6] = "0 to 100 %";    // DataRange
            source[7] = "Measured";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "연료 저장 용기의 총 부피에 대한 연료 부피의 비율.";  // 비고
            ListViewItem i119 = new ListViewItem(source);
            listView1.Items.Add(i119);
            source[1] = "95";    // SPN
            source[2] = "엔진 연료 필터 차압";    // Description
            source[3] = "1B";    // Size
            source[4] = "3";    // Start
            source[5] = "2 kPa/bit, 0 offet";    // Resoulution
            source[6] = "0 to 500 kPa";    // DataRange
            source[7] = "Measured";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "필터에 고체 또는 반고체 물질이 축적되어 필터 전체에서 측정된 연료 공급 압력의 변화.";  // 비고
            ListViewItem i120 = new ListViewItem(source);
            listView1.Items.Add(i120);
            source[1] = "99";    // SPN
            source[2] = "엔진 오일 필터 차압";    // Description
            source[3] = "1B";    // Size
            source[4] = "4";    // Start
            source[5] = "0.5 kPa/bit, 0 offset";    // Resoulution
            source[6] = "0 to 125 kPa";    // DataRange
            source[7] = "Measured";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "필터 내부의 축적되는 고체 및 반고체 물질로 인해 필터 전체에서 측정되는 엔진 오일 압력의 변화.";  // 비고
            ListViewItem i121 = new ListViewItem(source);
            listView1.Items.Add(i121);
            source[1] = "169";    // SPN
            source[2] = "화물 주변 온도";    // Description
            source[3] = "2B";    // Size
            source[4] = "5-6";    // Start
            source[5] = "0.03125 deg C/bit, -273 deg C offset";    // Resoulution
            source[6] = "-273 to 1734.96875 deg C";    // DataRange
            source[7] = "Measured";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "화물을 수용하는 데 사용되는 차량 컨테이너 내부의 공기 온도.";  // 비고
            ListViewItem i122 = new ListViewItem(source);
            listView1.Items.Add(i122);
            source[1] = "38";    // SPN
            source[2] = "연료 레벨 2";    // Description
            source[3] = "1B";    // Size
            source[4] = "7";    // Start
            source[5] = "0.4 %/bit, 0 offset";    // Resoulution
            source[6] = "0 to 100 %";    // DataRange
            source[7] = "Measured";    // Type
            source[8] = "";    // Value 비워둘것
            source[9] = "두 번째 또는 오른쪽 저장 컨테이너의 총 연료 부피에 대한 연료 부피의 비율입니다.";  // 비고
            ListViewItem i123 = new ListViewItem(source);
            listView1.Items.Add(i123);

            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            serialPort = new SerialPort();

            if (!serialPort.IsOpen)
            {
                connectToolStripMenuItem.Enabled = true;
                disconnectToolStripMenuItem.Enabled = false;
                btn_Save.Enabled = false;
                btn_Clear.Enabled = false;
            }

            thread = new Thread(Readqueue_Thread);
            if (onlyone)
            {
                thread.IsBackground = true; 
                thread.Start();
                onlyone = false;
            }
            

        }
        
        private async void Readqueue_Thread()
        {
            while (true)
            {
                if (serialPort.IsOpen)
                {
                    //que 안에 들어있는 데이터는 자릿수가 20이상인 온전한 데이터만 들어있다.
                    if (que.Count > 0 && listBox.InvokeRequired)
                    {
                        listBox.BeginInvoke(new MethodInvoker(delegate ()
                        {
                            try
                            {
                                ecuData = que.Dequeue();
                                listBox.Items.Add(ecuData);
                                listBox.SelectedIndex = listBox.Items.Count - 1;
                                listBox.SelectedIndex = -1;

                                ecuSubData = ecuData.Substring(3, 4);

                                // 예시) e0cf004008017d7d001400047d
                                // ecuData의 index 10부터 25까지가 DATA를 나타낸다.
                                // 10~11 = 첫번째 바이트, 12~13 = 두번째 바이트, 14~15 = 세번째 바이트, 16~17 = 네번째 바이트
                                // 18~19 = 다섯째 바이트, 20~21 = 여섯째 바이트, 22~23 = 일곱째 바이트, 24~25 = 여덟째 바이트

                                switch (ecuSubData)
                                {
                                    case "f003":   // PGN  61443  0xfoo3
                                        // index 10,11의 1.1, 1.2 = 가속 페달 1 저속 유휴 스위치
                                        // index 10,11의 1.3, 1.4 = 가속 페달 킥다운 스위치
                                        // index 10,11의 1.5, 1.6 = 도로 속도 제한 상태
                                        // index 10,11의 1.7, 1.8 = 가속 페달 2 저속 유휴 스위치
                                        // index 12,13 = 가속 페달 위치 1
                                        // index 14,15 = 현재 속도에서 엔진 퍼센트 부하
                                        // index 16,17 = 원격 가속 페달 위치
                                        // index 18,19 = 가속 페달 위치 2
                                        // index 20,21의 6.1, 6.2 = 차량 가속도 제한 상태
                                        ecuSubData = ecuData.Substring(20, 2);
                                        int state2979 = Convert.ToInt32(ecuSubData, 16);
                                        string temp2979 = Convert.ToString(state2979, 2);
                                        string state_2979 = temp2979.Substring(6, 1) + temp2979.Substring(7, 1);
                                        listView1.Items[8].SubItems[8].Text = state_2979;

                                        // index 20,21의 6.3, 6.4 = 순간 엔진 최대 출력 활성화 피드백
                                        // index 20,21의 6.5, 6.6 = DPF 열 관리 활성
                                        // index 20,21의 6.7, 6.8 = SCR 열 관리 활성
                                        // index 22,23 = 실제 최대 가용 엔진 – 퍼센트 토크
                                        // index 24,25 = 예상 펌핑 – 퍼센트 토크

                                        break;
                                    
                                    case "f004":   // PGN  61444  0xf004

                                        // index 10 = 엔진 토크 모드
                                        // index 11 = 실제 엔진 - 퍼센트 토크 고해상도

                                        // index 12~13 = 운전자 수요 엔진 - 퍼센트 토크
                                        ecuSubData = ecuData.Substring(12, 2);
                                        int torque_512 = Convert.ToInt32(ecuSubData, 16);
                                        torque_512 = torque_512 - 125;
                                        listView1.Items[16].SubItems[8].Text = torque_512.ToString() + "%";

                                        // index 14~15 = 실제 엔진 - 퍼센트 토크
                                        ecuSubData = ecuData.Substring(14, 2);
                                        int torque_513 = Convert.ToInt32(ecuSubData, 16);
                                        torque_513 = torque_513 - 125;
                                        listView1.Items[17].SubItems[8].Text = torque_513.ToString() + "%";

                                        // index 16~19 = 엔진 속도(RPM)
                                        ecuSubData = ecuData.Substring(18, 2);
                                        ecuSubData = ecuSubData + ecuData.Substring(16, 2);
                                        int rpm_190 = Convert.ToInt32(ecuSubData, 16);
                                        rpm_190 = rpm_190 * 125;
                                        rpm_190 = rpm_190 / 1000;
                                        listView1.Items[18].SubItems[8].Text = rpm_190.ToString()+ "rpm";

                                        // index 20~21 = 엔진 제어용 제어 장치의 소스주소
                                        // index 22 = 엔진 스타터 모드
                                        // index 23 = 사용안함

                                        // index 24~25 = 엔진 수요 - 퍼센트 토크
                                        ecuSubData = ecuData.Substring(24, 2);
                                        int torque_2432 = Convert.ToInt32(ecuSubData, 16);
                                        torque_2432 = torque_2432 - 125;
                                        listView1.Items[21].SubItems[8].Text = torque_2432.ToString()+ "%";

                                        break;

                                    case "f00e":    // PGN  61454
                                        // index 10~13 = NOx 흡기
                                        // index 14~17 = O2 흡기
                                        // index 18,19의 5.1, 5.2 = 흡기 가스 센서 전원 센서
                                        // index 18,19의 5.3, 5.4 = 온도에따른 흡기 가스 센서
                                        // index 18,19의 5.5, 5.6 = 흡기 NOx 안정 판독
                                        // index 18,19의 5.7, 5.8 = 넓은 범위의 % O2 안정 판독값
                                        // index 20,21의 6.1 ~ 6.5 = 흡기 NOx 센서 예비 FMI
                                        // index 20,21의 6.6, 6.7 = 흡기 가스 센서 히터 제어
                                        // index 22,23의 7.1 ~ 7.5 = 흡기 NOx 센서 예비 FMI
                                        // index 24,25의 8.1 ~ 8.5 = 흡기 산소 센서 예비 FMI

                                        break;

                                    case "f00f":    // PGN  61455
                                        // index 10~13 = NOx 배기
                                        // index 14~17 = O2 배기
                                        // index 18,19의 5.1, 5.2 = 배기 가스 센서 전원 상태
                                        // index 18,19의 5.3, 5.4 = 온도에 따른 배기 가스 센서
                                        // index 18,19의 5.5, 5.6 = 배기 NOx 안정 판독
                                        // index 18,19의 5.7, 5.8 = 배기, 넓은 범위의 % O2 판독값 안정
                                        // index 20,21의 6.1 ~ 6.5 = 배기 가스 센서 히터 예비 FMI
                                        // index 20,21의 6.6, 6.7 = 배기 가스 센서 히터 제어
                                        // index 22,23의 7.1 ~ 7.5 = 배기 NOx 센서 예비 FMI
                                        // index 24,25의 8.1 ~ 8.5 = 배기 산소 센서 예비 FMI

                                        break;

                                    case "f010":    // PGN  61456
                                        // index 10~13 = NOx 흡기
                                        // index 14~17 = O2 흡기
                                        // index 18,19의 5.1, 5.2 = 흡기 가스 센서 전원 상태
                                        // index 18,19의 5.3, 5.4 = 온도에서의 흡기 가스 센서
                                        // index 18,19의 5.5, 5.6 = 흡기 NOx 안정 판독
                                        // index 18,19의 5.7, 5.8 = 넓은 범위의 % O2 판독값 안정
                                        // index 20,21의 6.1 ~ 6.5 = 흡기 가스 센서 히터 예비 FMI
                                        // index 20,21의 6.6, 6.7 = 흡기 가스 센서 히터 제어
                                        // index 22,23의 7.1 ~ 7.5 = 흡기 NOx 센서 예비 FMI
                                        // index 24,25의 8.1 ~ 8.5  =  흡기 O2 센서 예비 FMI                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              

                                        break;

                                    case "f011":    // PGN  61457
                                        // index 10~13 = NOx 배기
                                        // index 14~17 = O2 배기
                                        // index 18,19의 5.1, 5.2 = 배기 가스 센서 전원 상태
                                        // index 18,19의 5.3, 5.4 = 온도에서의 배기 가스 센서
                                        // index 18,19의 5.5, 5.6 = 배기 NOx 안정 판독
                                        // index 18,19의 5.7, 5.8 = 배기, 넓은 범위의 % O2 판독값 안정
                                        // index 20,21의 6.1 ~ 6.5 = 배기 가스 센서 히터 예비 FMI
                                        // index 20,21의 6.6, 6.7 = 배기 가스 센서 히터 제어
                                        // index 22,23의 7.1 ~ 7.5 = 배기 NOx 센서 예비 FMI
                                        // index 24,25의 8.1 ~ 8.5 = 배기 산소 센서 예비 FMI

                                        break;

                                    case "f01a":    // PGN  61466
                                        // index 10~13 엔진 스로틀 액츄에이터 1 제어 명령
                                        // index 14~17 엔진 스로틀 액츄에이터 2 제어 명령
                                        // index 18~21 엔진 연료 액츄에이터 1 제어 명령
                                        // index 22~25 엔진 연료 액츄에이터 2 제어 명령

                                        break;

                                    case "fee5":   // PGN  65253

                                        // index 10~11,12~13,14~15,16~17 = 엔진 총 작동 시간
                                        ecuSubData = ecuData.Substring(16, 2);
                                        ecuSubData = ecuSubData + ecuData.Substring(14, 2);
                                        ecuSubData = ecuSubData + ecuData.Substring(12, 2);
                                        ecuSubData = ecuSubData + ecuData.Substring(10, 2);
                                        int hour_247 = Convert.ToInt32(ecuSubData, 16);
                                        hour_247 = hour_247 * 5;
                                        hour_247 = hour_247 / 100;
                                        listView1.Items[66].SubItems[8].Text = hour_247.ToString()+ "hour";

                                        // index 18~19,20~21,22~23,24~25 = 엔진 총 회전 수
                                        break;

                                    case "feee":   // PGN  65262
                                        // index 10~11 = 엔진 냉각수 온도
                                        ecuSubData = ecuData.Substring(10, 2);
                                        int temper_110 = Convert.ToInt32(ecuSubData, 16);
                                        temper_110 = temper_110 - 40;
                                        listView1.Items[68].SubItems[8].Text = temper_110.  ToString() + "℃";

                                        // index 12~13 = 엔진 연료 온도 1
                                        // index 14~17 = 엔진 오일 온도 1
                                        ecuSubData = ecuData.Substring(16, 2);
                                        ecuSubData = ecuSubData + ecuData.Substring(14, 2);
                                        int temper_175 = Convert.ToInt32(ecuSubData, 16);
                                        temper_175 = temper_175 * 3125;
                                        temper_175 = temper_175 / 100000;
                                        temper_175 = temper_175 - 273;
                                        listView1.Items[70].SubItems[8].Text = temper_175.ToString() + "℃";

                                        // index 18~21 = 엔진 터보차저 오일 온도
                                        // index 22~23 = 엔진 인터쿨러 온도
                                        ecuSubData = ecuData.Substring(22, 2);
                                        int temper_52 = Convert.ToInt32(ecuSubData, 16);
                                        temper_52 = temper_52 - 40;
                                        listView1.Items[72].SubItems[8].Text = temper_52.ToString() + "℃";

                                        // index 24~25 = 엔진 인터쿨러 서모스탯 개방

                                        break;

                                    case "feef":    // PGN  65263
                                        // index 10~11 = 엔진 연료 공급 압력
                                        ecuSubData = ecuData.Substring(10, 2);
                                        int pressure_94 = Convert.ToInt32(ecuSubData, 16);
                                        pressure_94 = pressure_94 * 4;
                                        listView1.Items[74].SubItems[8].Text = pressure_94.ToString() + "kPa";

                                        // index 12~13 = 엔진 확장 크랭크케이스 블로바이 압력
                                        // index 14~15 = 엔진 오일 레벨
                                        ecuSubData = ecuData.Substring(14, 2);
                                        int level_98 = Convert.ToInt32(ecuSubData, 16);
                                        level_98 = level_98 * 4;
                                        level_98 = level_98 / 10;
                                        if (level_98 > 100) { level_98 = 100; }
                                        listView1.Items[76].SubItems[8].Text = level_98.ToString() + "%";

                                        // index 16~17 = 엔진 오일 압력
                                        ecuSubData = ecuData.Substring(16, 2);
                                        int pressure_100 = Convert.ToInt32(ecuSubData, 16);
                                        pressure_100 = pressure_100 * 4;
                                        listView1.Items[77].SubItems[8].Text = pressure_100.ToString() + "kPa";

                                        // index 18~21 = 엔진 크랭크케이스 압력
                                        // index 22~23 = 엔진 냉각수 압력
                                        // index 24~25 = 엔진 냉각수 레벨
                                        ecuSubData = ecuData.Substring(24, 2);
                                        int level_111 = Convert.ToInt32(ecuSubData, 16);
                                        level_111 = level_111 * 4;
                                        level_111 = level_111 / 10;
                                        listView1.Items[80].SubItems[8].Text = level_111.ToString() + "%";
                                        
                                        break;

                                    case "fef1":    // PGN  65265
                                        // index 10~11의 1.1, 1.2 = 2단 속도 액슬 스위치
                                        // index 10~11의 1.3, 1.4 = 주차 브레이크 스위치
                                        ecuSubData = ecuData.Substring(10, 2);
                                        int state70 = Convert.ToInt32(ecuSubData, 16);
                                        string temp70 = Convert.ToString(state70, 2);
                                        string state_70 = temp70.Substring(4, 1) + temp70.Substring(5, 1);
                                        listView1.Items[82].SubItems[8].Text = state_70;

                                        // index 10~11의 1.5, 1.6 = 크루즈 컨트롤 일시 정지 스위치
                                        // index 10~11의 1.7, 1.8 = 주차 브레이크 해제 금지 요청
                                        // index 12~15 = 휠 기반 차량 속도
                                        ecuSubData = ecuData.Substring(14, 2);
                                        ecuSubData = ecuSubData + ecuData.Substring(12, 2);
                                        int speed_84 = Convert.ToInt32(ecuSubData, 16);
                                        speed_84 = speed_84 / 256;
                                        listView1.Items[85].SubItems[8].Text = speed_84.ToString() + "km/h";

                                        // index 16~17의 4.1, 4.2 = 크루즈 컨트롤 액티브
                                        // index 16~17의 4.3, 4.4 = 크루즈 컨트롤 활성화 스위치
                                        // index 16~17의 4.5, 4.6 = 브레이크 스위치
                                        // index 16~17의 4.7, 4.8 = 클러치 스위치
                                        // index 18~19의 5.1, 5.2 = 크루즈 컨트롤 세트 스위치
                                        // index 18~19의 5.3, 5.4 = 크루즈 컨트롤 코스트(감속) 스위치
                                        // index 18~19의 5.5, 5.6 = 크루즈 컨트롤 재개 스위치
                                        // index 18~19의 5.7, 5.8 = 크루즈 컨트롤 가속 스위치
                                        // index 20~21 = 크루즈 컨트롤 설정 속도
                                        // index 22~23 = 7.1 ~ 7.5 = PTO Governor State
                                        // index 22~23 = 7.6 ~ 7.8 = 크루즈 컨트롤 상태
                                        // index 24~25의 8.1, 8.2 = 엔진 공회전 증가 스위치
                                        // index 24~25의 8.3, 8.4 = 엔진 공회전 감소 스위치
                                        // index 24~25의 8.5, 8.6 = 엔진 테스트 모드 스위치
                                        // index 24~25의 8.7, 8.8 = 엔진 셧다운 오버라이드 스위치

                                        break;

                                    case "fef2":    // PGN  65266
                                        // index 10~13 = 엔진 연료 비율
                                        ecuSubData = ecuData.Substring(12, 2);
                                        ecuSubData = ecuSubData + ecuData.Substring(10, 2);
                                        int level_183 = Convert.ToInt32(ecuSubData, 16);
                                        level_183 = level_183 * 5;
                                        level_183 = level_183 / 100;
                                        listView1.Items[101].SubItems[8].Text = level_183.ToString() + "L/h";

                                        // index 14~17 = 엔진 순간 연비
                                        ecuSubData = ecuData.Substring(16, 2);
                                        ecuSubData = ecuSubData + ecuData.Substring(14, 2);
                                        int level_184 = Convert.ToInt32(ecuSubData, 16);
                                        level_184 = level_184 / 512;
                                        listView1.Items[102].SubItems[8].Text = level_184.ToString() + "km/L";

                                        // index 18~21 = 엔진 평균 연비
                                        ecuSubData = ecuData.Substring(20, 2);
                                        ecuSubData = ecuSubData + ecuData.Substring(18, 2);
                                        int level_185 = Convert.ToInt32(ecuSubData, 16);
                                        level_185 = level_185 / 512;
                                        listView1.Items[103].SubItems[8].Text = level_185.ToString() + "km/L";

                                        // index 22~23 = 엔진 스로틀 밸브 1 위치
                                        // index 24~25 = 엔진 스로틀 밸브 2 위치

                                        break;

                                    case "fef6":    // PGN  65270
                                        // index 10~11 = 엔진 디젤 미립자 필터 흡입 압력
                                        // index 12~13 = 엔진 흡기 매니폴드 #1 압력
                                        // index 14~15 = 엔진 흡기 매니폴드 1 온도
                                        // index 16~17 = 엔진 공기 흡입구 압력
                                        // index 18~19 = 엔진 에어 필터 1 압력차
                                        // index 20~23 = 엔진 배기 가스 온도
                                        // index 24~25 = 엔진 냉각수 필터 압력차

                                        break;

                                    case "fef7":    // PGN  65271
                                        // index 10~11 = 순 배터리 전류
                                        ecuSubData = ecuData.Substring(10, 2);
                                        int current_114 = Convert.ToInt32(ecuSubData, 16);
                                        current_114 = current_114 - 125;
                                        listView1.Items[113].SubItems[8].Text = current_114.ToString() + "A";

                                        // index 12~13 = 교류 발전기 전류
                                        ecuSubData = ecuData.Substring(12, 2);
                                        int current_115 = Convert.ToInt32(ecuSubData, 16);
                                        listView1.Items[114].SubItems[8].Text = current_115.ToString() + "A";

                                        // index 14~17 = 충전 시스템 전위(전압)
                                        ecuSubData = ecuData.Substring(16, 2);
                                        ecuSubData = ecuSubData + ecuData.Substring(14, 2);
                                        int voltage_167 = Convert.ToInt32(ecuSubData, 16);
                                        voltage_167 = voltage_167 * 5;
                                        voltage_167 = voltage_167 / 100;
                                        listView1.Items[115].SubItems[8].Text = voltage_167.ToString() + "V";

                                        // index 18~21 = 배터리 전위 / 전원 입력 1
                                        ecuSubData = ecuData.Substring(20, 2);
                                        ecuSubData = ecuSubData + ecuData.Substring(18, 2);
                                        int voltage_168 = Convert.ToInt32(ecuSubData, 16);
                                        voltage_168 = voltage_168 * 5;
                                        voltage_168 = voltage_168 / 100;
                                        listView1.Items[116].SubItems[8].Text = voltage_168.ToString() + "V";

                                        // index 22~25 = 키 스위치 배터리 전위
                                        ecuSubData = ecuData.Substring(24, 2);
                                        ecuSubData = ecuSubData + ecuData.Substring(22, 2);
                                        int voltage_158 = Convert.ToInt32(ecuSubData, 16);
                                        voltage_158 = voltage_158 * 5;
                                        voltage_158 = voltage_158 / 100;
                                        listView1.Items[117].SubItems[8].Text = voltage_158.ToString() + "V";

                                        break;

                                    case "fefc":    // PGN  65276
                                        // index 10~11 = 와셔액 레벨
                                        ecuSubData = ecuData.Substring(10, 2);
                                        int level_80 = Convert.ToInt32(ecuSubData, 16);
                                        level_80 = level_80 * 4;
                                        level_80 = level_80 / 10;
                                        if (level_80 > 100) { level_80 = 100; }
                                        listView1.Items[118].SubItems[8].Text = level_80.ToString() + "%";

                                        // index 12~13 = 연료 레벨
                                        ecuSubData = ecuData.Substring(12, 2);
                                        int level_96 = Convert.ToInt32(ecuSubData, 16);
                                        level_96 = level_96 * 4;
                                        level_96 = level_96 / 10;
                                        if(level_96 > 100) { level_96 = 100; }
                                        listView1.Items[119].SubItems[8].Text = level_96.ToString() + "%";

                                        break;
                                }
                            }
                            catch(Exception ex)
                            {
                                Debug.WriteLine(ex);
                            }
                        }));
                    }
                    else
                    {
                        try
                        {
                            listBox.Items.Add(que.Dequeue());
                            listBox.SelectedIndex = listBox.Items.Count - 1;
                            listBox.SelectedIndex = -1;

                            ecuSubData = ecuData.Substring(3, 4);

                            //파싱되는 switch 문 복사


                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex);
                        }
                    }
                }

                await Task.Delay(1);

            }
        }


        // form2로 부터 Data를 받아와서 처리하는 부분(시리얼통신을 통한 데이터 리시브가 아니다.)
        // https://dream-hacker.tistory.com/55 참고
        private void DataRecevieEvent(string[] data)
        {
            if (!serialPort.IsOpen)
            {
                string portname = data[0];
                string baudrate = data[1];
                string databits = data[2];
                string paratybits = data[3];
                string stopbits = data[4];
                string flowcontrol = data[5];


                listBox.SelectedIndex = listBox.Items.Count - 1;
                listBox.SelectedIndex = -1;


                // 이 이하로 시리얼통신 연결처리
                try
                {
                    serialPort.PortName = portname;
                    serialPort.BaudRate = int.Parse(baudrate);
                    serialPort.DataBits = int.Parse(databits);
                    serialPort.Parity = (Parity)(int.Parse(paratybits));
                    serialPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), stopbits, true);
                    serialPort.Handshake = (Handshake)(int.Parse(flowcontrol));
                    serialPort.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived);

                    serialPort.Open();  // 시리얼포트 열기

                    if (serialPort.IsOpen)
                    {
                        connectToolStripMenuItem.Enabled = false;
                        disconnectToolStripMenuItem.Enabled = true;

                        this.Text = "CANObserver (" + portname + ")";

                        btn_Save.Enabled = true;
                        btn_Clear.Enabled = true;

                        listBox.Items.Add(DateTime.Now.ToString("HH:mm:ss") + " " + "Connection was successful");
                    }            
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                }
            }
            else
            {
                listBox.Items.Add("The port is already open!!!");
            }
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.DataPassEvent += new Form2.DataPassEventHandler(DataRecevieEvent);
            form2.ShowDialog();
        }

        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)  // 수신이벤트 발생시 이 부분이 실행된다.
        {
            try
            {
                if (serialPort.IsOpen)
                {
                    string data = serialPort.ReadTo("\r");
                    if (data.Length > 20)
                    {
                        que.Enqueue(data);
                        Debug.WriteLine(data);

                        RdataNum++;

                        // 리시브 데이터 갯수를 카운트하는 부분
                        if (lbl_RxCount.InvokeRequired)
                        {
                            lbl_RxCount.BeginInvoke(new MethodInvoker(delegate ()
                            {
                                try
                                {
                                    lbl_RxCount.Text = RdataNum.ToString();
                                }catch (Exception ex)
                                {
                                    Debug.Write(ex);
                                }
                            }));
                        }
                        else
                        {
                            try
                            {
                                lbl_RxCount.Text = RdataNum.ToString();
                            }
                            catch (Exception ex)
                            {
                                Debug.Write(ex);
                            }
                        }

                    }
                    else
                    {
                        //Debug.WriteLine(data);
                    }
                }

                //await Task.Delay(1);

            }
            catch (Exception ex)
            {
                 Debug.WriteLine(ex);
            }

        }


        
        // 툴스트립 메뉴의 Quit 를 통한 종료
        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemSounds.Beep.Play();
            Application.Exit();
        }


        // 프로그램창의 X 버튼을 누를 시 이벤트
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SystemSounds.Beep.Play();
            if (MessageBox.Show("CANObserver를 종료하시겠습니까?", "종료", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if(serialPort.IsOpen)
                {
                    try
                    {
                        serialPort.Close();
                        listBox.Items.Add(DateTime.Now.ToString("HH:mm:ss") + " " + "SerialPort Closed OK");
                        thread.Interrupt();
                        this.Text = "CANObserver";
                        onlyone = true;
                        connectToolStripMenuItem.Enabled = true;
                        disconnectToolStripMenuItem.Enabled = false;

                    }
                    catch (Exception ex)
                    {
                        listBox.Items.Add("SerialPort Close Failed - " + ex);
                        Debug.WriteLine("SerialPort Close Failed - " + ex);
                    }
                }
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        

        // Clear버튼 클릭 이벤트
        private void btn_Clear_Click(object sender, EventArgs e)
        {
            listBox.Items.Clear();

            if (!serialPort.IsOpen)
            {
                btn_Clear.Enabled = false;
                btn_Save.Enabled = false;

                this.Text = "CANObserver";
            }
        }


        // Save버튼 클릭 이벤트
        private async void btn_Save_Click(object sender, EventArgs e)
        {
            SystemSounds.Beep.Play();
            for (int i = 0; i <= listBox.Items.Count - 1; i++)
            {
                LogWrite(listBox.Items[i].ToString());
            }

            listBox.Items.Clear();

            LogWrite(DateTime.Now.ToString("HH:mm:ss") + " " +"Save success");

            MessageBox.Show("저장이 완료되었습니다.", "Save success", MessageBoxButtons.OK);

            if (!serialPort.IsOpen)
            {
                btn_Clear.Enabled = false;
                btn_Save.Enabled = false;

                this.Text = "CANObserver";
            }

            await Task.Delay(10);
        }


        // 로그 디렉토리 및 로그파일 생성
        public void LogWrite(string str)
        {
            lock (lockObject)
            {
                string DirPath = Environment.CurrentDirectory + @"\LogFile";
                string FilePath = DirPath + "\\" + DateTime.Today.ToString("yyyyMMdd") + ".log";

                DirectoryInfo di = new DirectoryInfo(DirPath);
                FileInfo fi = new FileInfo(FilePath);

                try
                {
                    if (!di.Exists) Directory.CreateDirectory(DirPath);
                    if (!fi.Exists)
                    {
                        using (StreamWriter sw = new StreamWriter(FilePath))
                        {
                            sw.WriteLine(str);
                            sw.Close();
                        }
                    }
                    else
                    {
                        using (StreamWriter sw = File.AppendText(FilePath))
                        {
                            sw.WriteLine(str);
                            sw.Close();
                        }
                    }

                }
                catch (Exception e)
                {
                    //listBox.Items.Add("LogWrite Failed - " + e);
                    Debug.WriteLine("LogWrite Failed - " + e);
                }
            }
        }

        // Disconnect버튼 클릭 이벤트
        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("연결을 해제하시겠습니까?", "Disconnect", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    serialPort.Close();
                    listBox.Items.Add(DateTime.Now.ToString("HH:mm:ss") + " " + "SerialPort Closed OK");
                    thread.Interrupt();
                    this.Text = "CANObserver";
                    onlyone = true;
                    connectToolStripMenuItem.Enabled = true;
                    disconnectToolStripMenuItem.Enabled = false;
                    
                }
                catch (Exception ex)
                {
                    listBox.Items.Add("SerialPort Close Failed - " + ex);
                    Debug.WriteLine("SerialPort Close Failed - " + ex);
                }
            }
        }

        // 버튼 관련 단축키 이벤트
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (e.KeyCode == Keys.S)
                {
                    btn_Save_Click(sender, e);
                    e.SuppressKeyPress = true;
                }
                else if (e.KeyCode == Keys.C)
                {
                    btn_Clear_Click(sender, e);
                    e.SuppressKeyPress = true;
                }
            }
        }

    }
}
