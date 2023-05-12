using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageTask : MonoBehaviour {

    //TASK BOX
    public static List<string> taskTitle = new List<string>() 
    { 
        "TASKS LIST", 
        "МИССИИ",
        "ÉPREUVES",
        "MISSIONEN", 
        "TAREAS", 
        "TAREFAS",
        "المهام", 
        "TASKS LIST",
        "TASKS LIST",
        "任务清单",
        "BÀI TẬP" 
    };

    public static List<string> taskNote = new List<string>() 
    { 
        "Complete 10 tasks to get <color=#00ffffff>1 scratch card</color>.", 
        "Выполни 10 заданий, и получи <color=#00ffffff>1 скретч-карту</color>.",
        "Complete 10 tasks to get <color=#00ffffff>1 scratch card</color>.",
        "Complete 10 tasks to get <color=#00ffffff>1 scratch card</color>.", 
        "Complete 10 tasks to get <color=#00ffffff>1 scratch card</color>.", 
        "Complete 10 tasks to get <color=#00ffffff>1 scratch card</color>.",
        "Complete 10 tasks to get <color=#00ffffff>1 scratch card</color>.", 
        "Complete 10 tasks to get <color=#00ffffff>1 scratch card</color>.",
        "Complete 10 tasks to get <color=#00ffffff>1 scratch card</color>.",
        "Complete 10 tasks to get <color=#00ffffff>1 scratch card</color>.",
        "Hoàn thành 10 bài tập để nhận <color=#00ffffff>1 thẻ cào</color>." 
    };

    public static List<string> taskMessage = new List<string>() 
    { 
        "Task complete", 
        "Задание выполнено",
        "Mission accomplie",
        "Mission  erfüllt", 
        "Completado la tarea", 
        "Tarefa completar",
        "تمت المهمة", 
        "Task complete",
        "Task complete",
        "任务完成",
        "Bài tập hoàn thành" 
    };

    public static List<string> taskSkipNote = new List<string>() 
    { 
        "diamonds to skip", 
        "бриллиантов чтобы пропустить",
        "diamants pour continuer",
        "Diamanten zum Überspringen", 
        "diamantes para omitir", 
        "diamantes para pular",
        "diamonds to skip", 
        "ياقوتة للتخطي",
        "diamonds to skip",
        "颗钻石来跳过",
        "kim cương để bỏ" 
    };

    public static List<string> taskCantSkip = new List<string>() 
    { 
        "<color=red>Can't skip</color>", 
        "<color=red>Не удается пропустить</color>",
        "<color=red>Can't skip</color>",
        "<color=red>Kann nicht überspringen</color>", 
        "<color=red>No puedes saltearlo</color>", 
        "<color=red>Você não pode pular</color>",
        "<color=red>لا يمكن تخطي</color>", 
        "<color=red>スキップできません</color>",
        "<color=red>건너 뛸 수 없습니다</color>",
        "<color=red>不能 跳过</color>",
        "<color=red>Không thể bỏ qua</color>" 
    };

    public static List<string> taskNotEnough = new List<string>() 
    { 
        "Not enough DIAMOND", 
        "Недостаточно БРИЛЛИАНТОВ", 
        "Pas assez de PIÈCES", 
        "Nicht genügend MÜNZEN", 
        "No suficientes MONEDAS", 
        "Sem DIAMANTES suficientes", 
        "لا يكفي عملة", 
        "コインが 足りません",
        "충분하지 동전", 
        "没有足够的钻石", 
        "Không đủ kim cương" 
    };

    public static List<string> taskTitleBonus = new List<string>() 
    { 
        "COMPLETE 10 TASKS", 
        "ВЫПОЛНИ 10 МИССИЙ",
        "ACCOMPLIS 10 ÉPREUVES",
        "ERFÜLLE 10 MISSIONEN", 
        "COMPLETA 10 TAREAS", 
        "COMPLETE 10 TAREFAS",
        "أكمل 10 مهام", 
        "COMPLETE 10 TASKS",
        "COMPLETE 10 TASKS",
        "完成 10 个任务",
        "HOÀN THÀNH 10 BÀI TẬP" 
    };

    public static List<string> taskButSkip = new List<string>() 
    { 
        "SKIP", 
        "ПРОПУСТИТЬ",
        "PASSER",
        "ÜBERSPRINGEN", 
        "OMITIR", 
        "PULAR",
        "تخطي", 
        "SKIP",
        "SKIP",
        "跳过",
        "BỎ" 
    };

    public static List<List<string>> taskContent = new List<List<string>>() { 
        new List<string>()//0
        {
            "Collect 100 diamonds", 
            "Собрать 100 бриллиантов", 
            "Collectes 100 diamants",
            "Sammle 100 Diamanten ein",
            "Recoge 100 diamantes",
            "Colete 100 diamantes", 
            "أجمع 100 ياقوتة",
            "Collect 100 diamonds",
            "Collect 100 diamonds", 
            "搜集 100 顆鑽石", 
            "Thu thập 100 kim cương" 
        },
        new List<string>()//1
        {
            "Score 1000 points in one run", 
            "За один забег набрать 1000 очков", 
            "Marques 1000 points en une course",
            "Erreiche 1000 Punkte in einem Durchgang",
            "Consigue 1000 puntos en una carrera",
            "Marque 1000 pontos em uma corrida", 
            "حقق 1000 نقطة في جولة واحدة",
            "Score 1000 points in one run",
            "Score 1000 points in one run", 
            "單趟得分 1000 分", 
            "Đạt 1000 điểm trong 1 lần chạy" 
        },
        new List<string>()//2
        {
            "Pick up 2 Powerups", 
            "Собрать два любых бонуса", 
            "Prends 2 Bonus",
            "Sammle 2 Powerups ein",
            "Recoge 2 Powerups",
            "Pegue 2 Powerups", 
            "أحصل على أثنين من معززات القوة",
            "Pick up 2 Powerups",
            "Pick up 2 Powerups", 
            "撿到 2 個特殊道具", 
            "Thu thập 2 vật phẩm bất kỳ" 
        },
        new List<string>()//3
        {
            "Jump 20 times", 
            "Прыгнуть 20 раз (Проводя вниз по экрану вы ускорите прыжки)", 
            "Sautes 20 fois",
            "Springe 20 Mal",
            "Salta 20 veces",
            "Pule 20 vezes", 
            "اقفز 20 مرة",
            "Jump 20 times",
            "Jump 20 times", 
            "跳躍 20 次", 
            "Nhảy 20 lần" 
        },
        new List<string>()//4
        {
            "Use 1 hoverboard", 
            "Использовать 1 доску", 
            "Utilises 1 hoverboard",
            "Benutze 1 Hoverboard",
            "Usa 1 Aeropatín",
            "Use 1 Hoverboard", 
            "أستخدم الهوفربورد",
            "Use 1 hoverboard",
            "Use 1 hoverboard", 
            "使用 1 個漂浮滑板", 
            "Sử dụng 1 ván trượt" 
        },
        new List<string>()//5
        {
            "Pick up 2 Super Sneakers", 
            "Найдите и соберите 2 супер - ботинка", 
            "Prends 2 Super Baskets",
            "Sammle 2 Super Sneaker ein",
            "Recoge 2 Super Zapatillas",
            "Pegue 2 Super Sneakers", 
            "اجمع 2 من الحذاء الخارق",
            "Pick up 2 Super Sneakers",
            "Pick up 2 Super Sneakers", 
            "撿到 2 次超級球鞋", 
            "Thu thập 2 giày nhảy cao" 
        },
        new List<string>()//6
        {
            "Roll 10 times", 
            "Кувыркнуться 10 раз", 
            "Roules 10 fois",
            "Rolle dich 10 Mal",
            "Rueda por el suelo 10 veces",
            "Role 10 vezes", 
            "تدحرج 10 مرات",
            "Roll 10 times",
            "Roll 10 times", 
            "翻滾 10 次", 
            "Cuộn chui 10 lần" 
        },
        new List<string>()//7
        {
            "Crash into 5 barrels in one run", 
            "Врезаться а 5 бочек за один забег", 
            "Écrases-toi contre 5 tonneaux en une course",
            "Krache gegen 5 Fässer in einem Durchgang",
            "Choca contra 5 barriles en una carrera",
            "Se choque contra 5 barris emu ma corrida", 
            "اصطدم في 5 براميل في جولة واحدة",
            "Crash into 5 barrels in one run",
            "Crash into 5 barrels in one run", 
            "單趟衝撞 5 次火藥桶", 
            "Lao vào 5 thùng thuốc nổ" 
        },
        new List<string>()//8
        {
            "Score 2000 points in one run", 
            "За один забег набрать 2000 очков", 
            "Marques 2000 points en une course",
            "Erreiche 2000 Punkte in einem Durchgang",
            "Consigue 2000 puntos en una carrera",
            "Marque 2000 pontos em uma corrida", 
            "حقق 2000 نقطة فى جولة واحدة",
            "Score 2000 points in one run",
            "Score 2000 points in one run", 
            "單趟得分 2000 分", 
            "Đạt 2000 điểm trong 1 lần chạy" 
        },
        new List<string>()//9
        {
            "Roll 30 times", 
            "Кувыркнуться 30 раз", 
            "Roules 30 fois",
            "Rolle dich 30 Mal",
            "Rueda por el suelo 30 veces",
            "Role 30 vezes", 
            "تدحرج 30 مرة",
            "Roll 30 times",
            "Roll 30 times", 
            "翻滾 30 次", 
            "Cuộn chui 30 lần" 
        },
        new List<string>()//10
        {
            "Collect 100 diamonds with a jetpack", 
            "Собрать 100 бриллиантов на джетпаке", 
            "Collectes 100 diamants avec un jetpack",
            "Sammle 100 Diamanten mit einem Jetpack ein",
            "Recoge 100 diamantes con una Mochila Propulsora",
            "Colete 100 diamantes com o JetPack", 
            "أجمع 100 ياقوتة عن طريق الطيران",
            "Collect 100 diamonds with a jetpack",
            "Collect 100 diamonds with a jetpack", 
            "使用飛行背包搜集 100 顆鑽石", 
            "Thu thập 100 kim cương với thiết bị bay" 
        },
        new List<string>()//11
        {
            "Stay in same lane for 6 seconds", 
            "Оставаться 6 секунд на одной и той же линии", 
            "Restes sur la même voie pendant 6 secondes",
            "Bleibe 6 Sekunden lang in der gleichen Spur",
            "Quédate en el mismo carril por 6 segundos",
            "Fique na mesma faixa por 6 segundos", 
            "أبقَ في نفس الخط لمدة 6 ثوان",
            "Stay in same lane for 6 seconds",
            "Stay in same lane for 6 seconds", 
            "停留在同一條軌道 6 秒", 
            "Giữ nguyên làn chạy trong 6 giây" 
        },
        new List<string>()//12
        {
            "Collect 200 diamonds in one run", 
            "За один забег собрать 200 бриллиантов", 
            "Collectes 200 diamants en une course",
            "Sammle 200 Diamanten in einem Durchgang ein",
            "Recoge 200 diamantes en una carrera",
            "Colete 200 diamantes em uma corrida", 
            "أجمع 200 ياقوتة في جولة واحدة",
            "Collect 200 diamonds in one run",
            "Collect 200 diamonds in one run", 
            "單趟搜集 200 顆鑽石", 
            "Thu thập 200 kim cương trong 1 lần chạy" 
        },
        new List<string>()//13
        {
            "Score 500 points without collecting diamonds", 
            "Набрать 500 очков при этом не подбирая бриллиантов", 
            "Marques 500 point sans collecter des diamants",
            "Erreiche 500 Punkte ohne Diamanten einzusammeln",
            "Consigue 500 puntos sin recoger diamantes",
            "Marque 500 pontos sem coletar diamantes", 
            "حقق 500 نقطة بدون جمع الياقوت",
            "Score 500 points without collecting diamonds",
            "Score 500 points without collecting diamonds", 
            "得分 500 分且沒有 搜集到任何鑽石", 
            "Đạt 500 điểm mà không thu thập kim cương" 
        },
        new List<string>()//14
        {
            "Dodge 20 barriers", 
            "Увернуться от 20 препятствий", 
            "Esquives 20 barrières",
            "Weiche 20 Barrieren aus",
            "Esquiva 20 barreras",
            "Desvie de 20 barris", 
            "تجنب 20 برميل",
            "Dodge 20 barriers",
            "Dodge 20 barriers", 
            "閃過 20 次障礙", 
            "Tránh 20 hàng rào" 
        },
        new List<string>()//15
        {
            "Jump 20 times on any train top", 
            "Прыгни 20 раз на крышах поездов", 
            "Sautes 20 fois sur n'importe quel train",
            "Springe 20 Mal auf einem Zug",
            "Salta 20 veces encima de cualquier tren",
            "Pule 20 vezes no topo de qualquer trem", 
            "أقفز 20 مرة علي القطار",
            "Jump 20 times on any train top",
            "Jump 20 times on any train top", 
            "在任何火車上方跳躍 20 次", 
            "Nhảy 20 lần trên nóc tàu" 
        },
        new List<string>()//16
        {
            "Score 6000 points in one run", 
            "За один забег набрать 6000 очков", 
            "Marques 6000 points en une course",
            "Erreiche 6000 Punkte in einem Durchgang",
            "Consigue 6000 puntos en una carrera",
            "Marque 6000 pontos em uma corrida", 
            "حقق 6000 نقطة في جولة واحدة",
            "Score 6000 points in one run",
            "Score 6000 points in one run", 
            "單趟得分 6000 分", 
            "Đạt 6000 điểm trong 1 lần chạy" 
        },
        new List<string>()//17
        {
            "Complete 1 Daily Challenge", 
            "Выполнить 1 ежедневное задание", 
            "Relèves 1 défi quotidien",
            "Schließe 1 Tagesmission ab",
            "Completa 1 Reto Diario",
            "Complete 1 desafio diário", 
            "أكمل تحدي يومي واحد",
            "Complete 1 Daily Challenge",
            "Complete 1 Daily Challenge", 
            "完成ㄧ 個每日挑戰", 
            "Hoàn thành 1 thử thách bất kỳ" 
        },
        new List<string>()//18
        {
            "Collect 1000 diamonds in one run", 
            "Собрать 1000 бриллиантов за один забег", 
            "Collectes 1000 diamants en une course",
            "Sammle 1000 Diamanten in einem Durchgang ein",
            "Recoge 1000 diamantes en una carrera",
            "Colete 1000 diamantes em uma corrida", 
            "اجمع 1000 ياقوتة في جولة واحدة",
            "Collect 1000 diamonds in one run",
            "Collect 1000 diamonds in one run", 
            "單趟搜集 1000 顆鑽石", 
            "Thu thập 1000 kim cương trong 1 lần chạy" 
        },
        new List<string>()//19
        {
            "Jump 30 times in one run", 
            "За один забег попрыгать 30 раз", 
            "Sautes 30 fois en une course",
            "Springe 30 Mal in einem Durchgang",
            "Salta 30 veces en una carrera",
            "Pule 30 vezes em uma corrida", 
            "اقفز 30 مرة في جولة واحدة",
            "Jump 30 times in one run",
            "Jump 30 times in one run", 
            "單趟跳躍 30 次", 
            "Nhảy 30 lần trong 1 lần chạy" 
        },
        new List<string>()//20
        {
            "Buy 1 Safe Box", 
            "Купить один сейф", 
            "Achètes 1 coffre fort",
            "Kaufe 1 Tresor",
            "Compra 1 Caja Fuerte",
            "Compre um Safe Box", 
            "أشتري صندوق أمان واحد",
            "Buy 1 Safe Box",
            "Buy 1 Safe Box", 
            "買 1 個保險箱", 
            "Mua 1 hộp bí ẩn" 
        },
        new List<string>()//21
        {
            "Pick up 3 Diamond Vacuums", 
            "Собрать 3 пылесоса для бриллиантов", 
            "Prends 3 aspirateurs à diamant",
            "Sammle 3 Diamantensauger ein",
            "Recoge 3 Aspiradoras de Diamantes",
            "Pegue 3 Diamond Vacuums", 
            "أجمع 3 من جامع الياقوت",
            "Pick up 3 Diamond Vacuums",
            "Pick up 3 Diamond Vacuums", 
            "撿到 3 個鑽石吸塵器", 
            "Thu thập 3 nam châm" 
        },
        new List<string>()//22
        {
            "Stay in same lane for 8 seconds", 
            "Оставаться 8 секунд на одной и той же линии", 
            "Restes sur la même voie pendant 8 secondes",
            "Bleibe 8 Sekunden lang in der gleichen Spur",
            "Quédate en el mismo carril por 8 segundos",
            "Fique na mesma faixa por 8 segundos", 
            "أبق في نفس الخط لمدة 8 ثوان",
            "Stay in same lane for 8 seconds",
            "Stay in same lane for 8 seconds", 
            "停留在同ㄧ軌道 8 秒", 
            "Giữ nguyên làn chạy trong 8 giây" 
        },
        new List<string>()//23
        {
            "Stumble into 2 barriers", 
            "Столкнуться с препятствием 2 раза", 
            "Trébuches sur 2 barrières",
            "Krache gegen 2 Barrieren",
            "Tropieza con 2 barriles",
            "Tropece em 2 barreiras", 
            "تعثر ببرميلين",
            "Stumble into 2 barriers",
            "Stumble into 2 barriers", 
            "跌入 2 個障礙中", 
            "Trượt chân vào 2 hàng rào" 
        },
        new List<string>()//24
        {
            "Beat Your High Score", 
            "Побить свой рекорд", 
            "Bats ton record",
            "Schlage deinen High-Score",
            "Supera tu Puntación Más Alta",
            "Bata sua pontuação mais alta", 
            "تخطي رقمكَ القياسي",
            "Beat Your High Score",
            "Beat Your High Score", 
            "擊敗你自己 的最高分", 
            "Vượt điểm cao nhất của bạn" 
        },
        new List<string>()//25
        {
            "Pick up 2 Jetpacks in one run", 
            "Собрать 2 Джетпака (за один забег)", 
            "Prends 2 Jetpacks en une course",
            "Pick up 2 Jetpacks in one run",
            "Recoge 2 mochilas propulsoras en una carrera",
            "Pegue 2 JetPacks em uma corrida", 
            "اجمع 2 من اداة الطيران في جولة واحدة",
            "Pick up 2 Jetpacks in one run",
            "Pick up 2 Jetpacks in one run", 
            "單趟撿到 2 個飛行背包", 
            "Thu thập 2 thiết bị bay trong 1 lần chạy" 
        },
        new List<string>()//26
        {
            "Use 7 Score boosters in one run", 
            "Использовать 7 Умножителей счета за один забег", 
            "Utilises 7 boosters de score en une course",
            "Benutze 7 Punktebooster in einem Durchgang",
            "Usa  7 Optimizadores de Puntuación en una carrera",
            "Use 7 Score Boosters em uma corrida", 
            "استخدم 7 من معززات النقاط فى جولة واحدة",
            "Use 7 Score boosters in one run",
            "Use 7 Score boosters in one run", 
            "單趟使用 7 個分數加速器", 
            "Sử dụng 7 điểm cộng trong 1 lần chạy" 
        },
        new List<string>()//27
        {
            "Bump into 3 trains in one run but don’t crash", 
            "Врезаться в поезд за один забег 3 раза", 
            "Cognes-toi à 3 trains en une course sans t'écraser",
            "Stoße gegen 3 Züge, krache aber nicht gegen sie",
            "Tropieza con 3 trenes en una carrera pero no choques",
            "Encoste em 3 trens emu ma corrida, mas não bata", 
            "اصطدم بثلاث قطارات ولكن لا تخسر",
            "Bump into 3 trains in one run but don’t crash",
            "Bump into 3 trains in one run but don’t crash", 
            "單趟擦撞火車 3 次但不要 撞到東西", 
            "Đụng chạm 3 thành tàu mà không bị bắt" 
        },
        new List<string>()//28
        {
            "Pickup 50 diamonds with a Vacuum", 
            "Собрать с помощью пылесоса 50 бриллиантов", 
            "Prends 50 diamants avec un aspirateur",
            "Sammle 50 Diamanten mit einem Sauger",
            "Recoge 50 diamantes con una Aspiradora",
            "Pegue 50 diamantes com o Vaccum", 
            "اجمع 50 ياقوتة باستخدام جامع الياقوت",
            "Pickup 50 diamonds with a Vacuum",
            "Pickup 50 diamonds with a Vacuum", 
            "使用鑽石吸塵 器搜集 50 顆鑽石", 
            "Thu thập 50 kim cương bằng nam châm" 
        },
        new List<string>()//29
        {
            "Get caught within the first 10 seconds of a run", 
            "Вас должен поймать инспектор в первые 10 секунд забега", 
            "Fais-toi prendre dans les 10 premières secondes de la course",
            "Werde innerhalb der ersten 10 Sekunden geschnappt",
            "Se atrapado en los primeros 10 segundos de una carrera",
            "Seja pego nos primeiros 10 segundos da corrida", 
            "استسلم في خلال 10 ثواني من اللعب",
            "Get caught within the first 10 seconds of a run",
            "Get caught within the first 10 seconds of a run", 
            "在前 10 秒內被抓到", 
            "Bị bắt trong 10 giây khi bắt đầu chạy" 
        },
        new List<string>()//30
        {
            "Use 1 Hoverboard without crashing", 
            "Использовать одну доску без столкновений с барьерами, поездами", 
            "Utilises 1 Hoverboard sans t'écraser",
            "Benutze 1 Hoverboard ohne zu crashen",
            "Usa 1 Aeropatín sin chocar",
            "Use 1 Hoverboard sem se chocar", 
            "استخدم الهوفربورد بدون تصادم",
            "Use 1 Hoverboard without crashing",
            "Use 1 Hoverboard without crashing", 
            "使用 1 個漂浮滑板", 
            "Sử dụng 1 ván trượt mà không bị ngã" 
        },
        new List<string>()//31
        {
            "Pick up 2 Safe Boxes", 
            "Собрать 2 Сейфа", 
            "Prends 2 coffres-forts",
            "Sammle 2 Tresor ein",
            "Recoge 2 Cajas Fuertes",
            "Pegue 2 Safe Box", 
            "اجمع 2 من صناديق الأمان",
            "Pick up 2 Safe Boxes",
            "Pick up 2 Safe Boxes", 
            "撿到 2 個保險箱", 
            "Thu thập 2 hộp bí ẩn" 
        },
        new List<string>()//32
        {
            "Use 3 Hoverboards without crashing in 1 run", 
            "Использовать 3 доски без столкновений с барьерами, поездами", 
            "Utilises 3 Hoverboards sans t'écraser en une course",
            "Benutze 3 Hoverboards in einem Durchgang ohne gegen etwas zu krachen",
            "Usa 3 Aeropatines sin chocar en una carrera",
            "Use 3 Hoverboards sem se chocar em 1 corrida", 
            "استخدم 3 هوفربورد بدون تصادم في جولة واحدة",
            "Use 3 Hoverboards without crashing in 1 run",
            "Use 3 Hoverboards without crashing in 1 run", 
            "在 1 回中使用 3 次漂浮滑 板且沒有 撞到東西", 
            "Sử dụng 3 ván trượt mà không ngã trong 1 lần chạy" 
        },
        new List<string>()//33
        {
            "Run on roofs of 10 monorail trains", 
            "Пробежать по крыше 10 воздушных поездов", 
            "Cours sur les toits de 10 monorails",
            "Renne auf den Dächern von 10 Schwebebahnen",
            "Corre en los techos de 10 trenes monorraíles",
            "Corra no teto de 10 trens monotrilhos", 
            "اركض علي 10 قطارات طائرة",
            "Run on roofs of 10 monorail trains",
            "Run on roofs of 10 monorail trains", 
            "在單軌火 車上方跑 10 次", 
            "Chạy trên nóc của 10 tàu treo" 
        },
        new List<string>()//34
        {
            "Pick up 12 Powerups", 
            "Собрать 12 бонусов", 
            "Prends 12 Bonus",
            "Sammle 12 Powerups ein",
            "Recoge 12 Powerups",
            "Pegue 12 Powerups", 
            "اجمع 12 من معززات القوة",
            "Pick up 12 Powerups",
            "Pick up 12 Powerups", 
            "撿到 12 次特殊道具", 
            "Thu thập 12 vật phẩm bất kỳ" 
        },
        new List<string>()//35
        {
            "Run on Roofs of 10 ground trains", 
            "Пробежать по крыше 10 наземных поездов", 
            "Cours sur les toits de 10 trains",
            "Renne auf 10 Zugdächern",
            "Corre en los techos de 10 trenes de tierra",
            "Corra no teto de 10 trens terrestres", 
            "اركض علي 10 قطارات أرضية",
            "Run on Roofs of 10 ground trains",
            "Run on Roofs of 10 ground trains", 
            "在地面火 車上方跑 10 次", 
            "Chạy trên nóc của 10 tàu hỏa" 
        },
        new List<string>()//36
        {
            "Score 1000 points without collecting diamonds", 
            "Набрать 1000 очков при этом не подбирая бриллиантов", 
            "Marques 1000 points sans collecter des diamants",
            "Erreiche 1000 Punkte ohne Diamanten einzusammeln",
            "Consigue 1000 puntos sin recoger diamantes",
            "Marque 1000 pontos sem coletar diamantes", 
            "اجمع 1000 نقطة بدون جمع الياقوت",
            "Score 1000 points without collecting diamonds",
            "Score 1000 points without collecting diamonds", 
            "得 1000 分且沒有 搜集到 1 顆鑽石", 
            "Đạt 1000 điểm mà không thu thập kim cương" 
        },
        new List<string>()//37
        {
            "Dodge/jump over 10 barrels", 
            "Увернуться от 10 бочек", 
            "Esquives/sautes sur 10 tonneaux",
            "Spring über/Weiche 10 Fässern aus",
            "Esquiva/salta por encima de 10 barriles",
            "Desvie/Salte sobre 10 barris", 
            "تخطي أكثر من 10 براميل",
            "Dodge/jump over 10 barrels",
            "Dodge/jump over 10 barrels", 
            "閃過/跳過 10 桶火藥桶", 
            "Tránh/Nhảy qua 10 thùng thuốc nổ" 
        },
        new List<string>()//38
        {
            "Pick up 5 Super Sneakers", 
            "Собрать 5 пар супер-ботинок", 
            "Prends 5 Super baskets",
            "Sammle 5 Super Sneaker ein",
            "Recoge 5 Super Zapatillas",
            "Pegue 5 Super Sneakers", 
            "اجمع 5 من الحذاء الخارق",
            "Pick up 5 Super Sneakers",
            "Pick up 5 Super Sneakers", 
            "撿到 5 次超級球鞋", 
            "Thu thập 5 giày nhảy cao" 
        },
        new List<string>()//39
        {
            "Use 4 Score Boosters", 
            "Использовать увеличитель очков 4 раза", 
            "Utilises 4 boosters de score",
            "Benutze 4 Scorebooster",
            "Usa 4 Optimizadores de Puntuación",
            "Use 4 Score Boosters", 
            "4 من معززات النقاط",
            "Use 4 Score Boosters",
            "Use 4 Score Boosters", 
            "使用 4 次分數加速器", 
            "Sử dụng 4 điểm cộng" 
        },
        new List<string>()//40
        {
            "Dodge/jump over 30 barrels", 
            "Увернуться от 30 бочек", 
            "Esquives/sautes sur 30 tonneaux",
            "Spring über 30 Fässer",
            "Esquiva/salta por encima de 30 barriles",
            "Desvie/Salte sobre 30 barris", 
            "النقاط/اقفز فوق 30 برميل",
            "Dodge/jump over 30 barrels",
            "Dodge/jump over 30 barrels", 
            "閃過/跳過 30 桶火藥桶", 
            "Tránh/Nhảy qua 30 thùng thuốc nổ" 
        },
        new List<string>()//41
        {
            "Pick up 200 diamonds with a vacuum", 
            "Собрать 200 бриллиантов с помощью пылесоса", 
            "Prends 200 diamants avec un aspirateur",
            "Sammle 200 Diamanten mit einem Sauger ein",
            "Recoge 200 diamantes con una Aspiradora",
            "Pegue 200 diamantes com o Vacuum", 
            "اجمع 200 ياقوتة باستخدام جامع الياقوت",
            "Pick up 200 diamonds with a vacuum",
            "Pick up 200 diamonds with a vacuum", 
            "使用鑽石 吸塵器搜集 200 顆鑽石", 
            "Thu thập 200 kim cương với nam châm" 
        },
        new List<string>()//42
        {
            "Pick up 5 vacuums in one run", 
            "Собрать за один забег 5 пылесоса", 
            "Prends 5 aspirateurs en une course",
            "Sammle 5 Diamantensauger in einem Durchgang ein",
            "Recoge 5 Aspiradoras en una carrera",
            "Pegue 5 Vacuums em uma corrida", 
            "اجمع 5 من جامعات الياقوت في جولة واحدة",
            "Pick up 5 vacuums in one run",
            "Pick up 5 vacuums in one run", 
            "單趟撿到 5 台鑽 石吸塵器", 
            "Thu thập 5 nam châm trong 1 lần chạy" 
        },
        new List<string>()//43
        {
            "Pick up 5 Safe Boxes in one run", 
            "Собрать 5 сейфа за один забег", 
            "Prends 5 coffres-forts en une course",
            "Sammle 5 Tresore in einem Durchgang ein",
            "Recoge 5 Cajas Fuertes en una carrera",
            "Pegue 5 Safe Box em uma corrida", 
            "اجمع 5 صناديق أمان في جولة واحدة",
            "Pick up 5 Safe Boxes in one run",
            "Pick up 5 Safe Boxes in one run", 
            "單趟撿到 5 個保險箱", 
            "Thu thập 5 hộp bí ẩn trong 1 lần chạy" 
        },
        new List<string>()//44
        {
            "Roll 40 times in one run", 
            "Кувыркнуться за 1 забег 40 раз", 
            "Roules 40 fois en une course",
            "Rolle 40 Mal in einem Durchgang",
            "Rueda por el suelo 40 veces en una carrera",
            "Role 40 vezes em uma corrida", 
            "تدحرج 40 مرة في جولة واحدة",
            "Roll 40 times in one run",
            "Roll 40 times in one run", 
            "單趟翻滾 40 次", 
            "Cuộn chui 40 lần trong 1 lần chạy" 
        },
        new List<string>()//45
        {
            "Collect 400 diamonds in one run", 
            "Собрать за 1 забег 400 бриллиантов", 
            "Collectes 400 diamants en une course",
            "Sammle 400 Diamanten in einem Durchgang",
            "Recoge 400 diamantes en una carrera",
            "Colete 400 diamantes em uma corrida", 
            "اجمع 400 ياقوتة في جولة واحدة",
            "Collect 400 diamonds in one run",
            "Collect 400 diamonds in one run", 
            "單趟搜集 400 顆鑽石", 
            "Thu thập 400 kim cương trong 1 lần chạy" 
        },
        new List<string>()//46
        {
            "Stay in same lane for 10 seconds", 
            "Оставаться 10 секунд на одной и той же линии", 
            "Restes sur la même voie pendant 10 secondes",
            "Bleibe 10 Sekunden lang in der gleichen Spur",
            "Quédate en el mismo carril por 10 segundos",
            "Fique na mesma faixa por 10 segundos", 
            "أبق في نفس الخط لمدة 10 ثوان",
            "Stay in same lane for 10 seconds",
            "Stay in same lane for 10 seconds", 
            "停留在同 一軌道 10 秒", 
            "Giữ nguyên làn chạy trong 10 giây" 
        },
        new List<string>()//47
        {
            "Collect 100,000 points", 
            "Набрать 100,000 очков", 
            "Collectes 100,000 points",
            "Sammle 100,000 Punkte",
            "Consigue 100,000 puntos",
            "Colete 100,000 pontos", 
            "أجمع 100,000 نقطة",
            "Collect 100,000 points",
            "Collect 100,000 points", 
            "得分 100,000 分", 
            "Đạt 100,000 điểm" 
        },
        new List<string>()//48
        {
            "Pick up 5 Jetpacks", 
            "Собрать 5 Джетпаков", 
            "Prends 5 Jetpacks",
            "Sammle 5 Jetpacks ein",
            "Recoge 5 Mochilas Propulsoras",
            "Pegue 5 JetPacks", 
            "اجمع 5 من أداة الطيران",
            "Pick up 5 Jetpacks",
            "Pick up 5 Jetpacks", 
            "撿到 5 個飛行背包", 
            "Thu thập 5 thiết bị bay" 
        },
        new List<string>()//49
        {
            "Crash into 10 barrels in one run", 
            "Врезаться а 10 бочек за один забег", 
            "Écrases-toi contre 10 tonneaux en une course",
            "Krache in einem Durchgang in 10 Fässer",
            "Cocha con 10 barriles en una carrera",
            "Bata em 10 barris em uma corrida", 
            "اصطدم في 10 براميل في جولة واحدة",
            "Crash into 10 barrels in one run",
            "Crash into 10 barrels in one run", 
            "單趟撞到 10 次火藥桶", 
            "Va chạm 10 thùng thuốc nổ trong 1 lần chạy" 
        },
        new List<string>()//50
        {
            "Pick up 3 Super Sneakers in one run", 
            "Собрать за один забег 3 супер-ботинка", 
            "Prends 3 Super Baskets en une course",
            "Sammle 3 Super Sneaker ein",
            "Recoge 3 Super Zapatillas en una carrera",
            "Pegue 3 Super Sneakers em uma corrida", 
            "اجمع 3 من الحذاء الخارق في جولة واحدة",
            "Pick up 3 Super Sneakers in one run",
            "Pick up 3 Super Sneakers in one run", 
            "單趟撿到 3 次超級球鞋", 
            "Thu thập 3 giày nhảy cao trong 1 lần chạy" 
        },
        new List<string>()//51
        {
            "Roll 30 times on ground train Roofs", 
            "Кувыркнуться 30 раз на крыше наземных поездов", 
            "Roules 30 fois sur le toit des trains",
            "Rolle 30 Mal auf Zugdächern",
            "Rueda en el suelo 30 veces en los techos de los trenes de tierra",
            "Role 30 vezes nos tetos dos trens terrestres", 
            "تدحرج 30 مرة فوق قطار أرضي",
            "Roll 30 times on ground train Roofs",
            "Roll 30 times on ground train Roofs", 
            "在地面火 車頂上翻滾 30 次", 
            "Cuộn chui 30 lần trên nóc tàu hỏa" 
        },
        new List<string>()//52
        {
            "Score 50,000 points in one run", 
            "Набрать 50,00 очков (за один забег)", 
            "Marques 50,000 points en une course",
            "Erreiche 50,000 Punkte in einem Durchgang",
            "Consigue 50,000 puntos en una carrera",
            "Marque 50,000 pontos em uma corrida", 
            "حقق 50,000 نقطة في جولة واحدة",
            "Score 50,000 points in one run",
            "Score 50,000 points in one run", 
            "單趟得分 50,000 分", 
            "Đạt 50,000 điểm trong 1 lần chạy" 
        },
        new List<string>()//53
        {
            "Spend 50,000 diamonds", 
            "Потратить на что-нибудь 50,000 бриллиантов", 
            "Dépenses 50,000 diamants",
            "Gebe 50,000 Diamanten aus",
            "Gasta 50,000 diamantes",
            "Gaste 50,000 diamantes", 
            "انفق 50,000 ياقوتة",
            "Spend 50,000 diamonds",
            "Spend 50,000 diamonds", 
            "花費 50,000 顆鑽石", 
            "Tiêu thụ 50,000 kim cương" 
        },
        new List<string>()//54
        {
            "Roll 30 times on monorail train Roofs", 
            "Кувыркнуться 30 раз на крыше воздушных поездов", 
            "Roules 30 fois sur les toits des monorails",
            "Rolle 30 Mal auf den Dächern von Schwebebahnen",
            "Rueda en el suelo 30 veces en los techos de los trenes monorraíles",
            "Role 30 vezes nos tetos dos trens monotrilhos", 
            "تدحرج 30 مرة فوق قطار طائر",
            "Roll 30 times on monorail train Roofs",
            "Roll 30 times on monorail train Roofs", 
            "在單軌火車 上方翻滾 30 次", 
            "Cuộn chui 30 lần trên nóc tàu treo" 
        },
        new List<string>()//55
        {
            "Bump into 6 trains in one run", 
            "Столкнуться 6 поездами (за один забег)", 
            "Cognes-toi à 6 trains en une course",
            "Stoße gegen 6 Züge in einem Durchgang",
            "Tropieza con 6 trenes en una carrera",
            "Encoste em 6 trens em uma corrida", 
            "اصطدم في 6 قطارات في جولة واحدة",
            "Bump into 6 trains in one run",
            "Bump into 6 trains in one run", 
            "單趟擦撞火車 6 次", 
            "Va chạm thành tàu 6 lần trong 1 lần chạy" 
        },
        new List<string>()//56
        {
            "Use 3 Hoverboards without crashing", 
            "Использовать 3 доски-hoverboard (без столкновений)", 
            "Utilises 3 Hoverboards sans t'écraser",
            "Benutze 3 Hoverboards ohne zu crashen",
            "Usa 3 Aeropatines sin chocar",
            "Use 3 Hoverboards sem se chocar", 
            "استخدم 3 من الهوفربورد بدون تصادم",
            "Use 3 Hoverboards without crashing",
            "Use 3 Hoverboards without crashing", 
            "使用 3 次漂浮滑板且 沒有撞到 任何東西", 
            "Sử dụng 3 ván trượt mà không ngã" 
        },
        new List<string>()//57
        {
            "Pick up 2 Keys", 
            "Подобрать 2 ключа", 
            "Prends 2 clés",
            "Sammle 2 Schlüssel ein",
            "Recoge 2 Llaves",
            "Pegue 2 chaves", 
            "اجمع مفتاحين",
            "Pick up 2 Keys",
            "Pick up 2 Keys", 
            "撿到 2 支鑰匙", 
            "Thu thập 2 chìa khóa" 
        },
        new List<string>()//58
        {
            "Collect 250,000 points", 
            "Набрать 250,000 очков", 
            "Collectes 250,000 points",
            "Sammle 250,000 Punkte",
            "Consigue 250,000 puntos",
            "Colete 250,000 pontos", 
            "اجمع 250,000 نقطة",
            "Collect 250,000 points",
            "Collect 250,000 points", 
            "得到 250,000 分", 
            "Đạt 250,000 điểm" 
        },
        new List<string>()//59
        {
            "Unlock any jetpack", 
            "Разблокировать любой джетпак", 
            "Débloques des jetpacks",
            "Schalte einen Jetpack frei",
            "Desbloquea cualquier mochila propulsora",
            "Desbloqueie  qualquer JetPack", 
            "افتح أدوات الطيران",
            "Unlock any jetpack",
            "Unlock any jetpack", 
            "解鎖任何 飛行背包", 
            "Mở khóa bất kỳ thiết bị bay" 
        },
        new List<string>()//60
        {
            "Stumble into 15 barriers", 
            "Дотронуться до 15 барьеров (прыгнуть на них сверху)", 
            "Trébuches sur 15 barrières",
            "Krache gegen 15 Barrieren",
            "Tropieza con 15 barreras",
            "Tropece em 15 barreiras", 
            "تعثر في 15 برميل",
            "Stumble into 15 barriers",
            "Stumble into 15 barriers", 
            "跌入 15 次障礙中", 
            "Trượt chân vào 15 hàng rào" 
        },
        new List<string>()//61
        {
            "Buy 3 Safes", 
            "Купить 3 Сейфа", 
            "Achètes 3 coffres-forts",
            "Kaufe 3 Tresore",
            "Compra 3 Caja Fuertes",
            "Compre 3 cofres", 
            "أشتري 3 من الأمان",
            "Buy 3 Safes",
            "Buy 3 Safes", 
            "買 3 個保險箱", 
            "Mua 3 hộp bí ẩn" 
        },
        new List<string>()//62
        {
            "Pickup 250 diamonds with a Vacuum", 
            "Собрать 250 бриллиантов с помощью пылесоса", 
            "Prends 250 diamants avec un aspirateur",
            "Sammle 250 Diamenten mit einem Diamantensauger ein",
            "Recoge 250 diamantes con una Aspiradora",
            "Pegue 250 diamantes com o vacuum", 
            "اجمع 250 ياقوتة باستخدام جامع الياقوت",
            "Pickup 250 diamonds with a Vacuum",
            "Pickup 250 diamonds with a Vacuum", 
            "使用鑽石吸 塵器搜集 250 顆鑽石", 
            "Thu thập 250 kim cương với nam châm" 
        },
        new List<string>()//63
        {
            "Dodge 80 barriers", 
            "Увернуться от 80 препятствий", 
            "Esquives 80 barrières",
            "Weiche 80 Barrieren aus",
            "Esquiva 80 barreras",
            "Desvie de 80 barreiras", 
            "تخطي 80 برميل",
            "Dodge 80 barriers",
            "Dodge 80 barriers", 
            "閃過 80 次障礙", 
            "Tránh 80 hàng rào" 
        },
        new List<string>()//64
        {
            "Spend 80,000 coins", 
            "Потратить на что-нибудь 80,000 монет", 
            "Dépenses 80,000 pièces",
            "Gebe 80,000 Münzen aus",
            "Gasta 80,000 monedas",
            "Gaste 80,000 moedas", 
            "انفق 80,000",
            "Spend 80,000 coins",
            "Spend 80,000 coins", 
            "花費 80,000 金幣", 
            "Tiêu thụ 80,000 kim cương" 
        },
        new List<string>()//65
        {
            "Pick up 4 Super Sneakers in one run", 
            "Собрать 4 пары супер-ботинок (за один забег)", 
            "Prends 4 Super Baskets",
            "Sammle 4 Super Sneacker in einem Durchgang ein",
            "Recoge 4 Super Zapatillas en una carrera",
            "Pegue 4 Super Sneakers em uma corrida", 
            "اجمع 4 أحذية خارقة في جولة واحدة",
            "Pick up 4 Super Sneakers in one run",
            "Pick up 4 Super Sneakers in one run", 
            "單趟撿到 4 次超級球鞋", 
            "Thu thập 4 giày nhảy cao trong 1 lần chạy" 
        },
        new List<string>()//66
        {
            "Unlock any hoverbike", 
            "Разблокировать любой ховербайк", 
            "Débloques un hoverbike",
            "Schalte ein Hoverbike frei",
            "Desbloquea cualquier Aerobicicleta",
            "Desbloqueie a Hoverbike", 
            "أفتح الهوفر بايك",
            "Unlock any hoverbike",
            "Unlock any hoverbike", 
            "解鎖任何 漂浮腳架車", 
            "Mở khóa bất kỳ ván trượt nào" 
        },
        new List<string>()//67
        {
            "Pick up 15 Jetpacks", 
            "Поднять15 джетпаков", 
            "Prends 15 jetpacks",
            "Sammle 15 Jetpacks ein",
            "Recoge 15 mochilas propulsorass",
            "Pegue 15 JetPacks", 
            "اجمع 15 من ادوات الطيران",
            "Pick up 15 Jetpacks",
            "Pick up 15 Jetpacks", 
            "撿到 15 次飛行背包", 
            "Thu thập 15 thiết bị bay" 
        },
        new List<string>()//68
        {
            "Pick up 8 Safes", 
            "Собрать 8 сейфов", 
            "Prends 8 coffres-forts",
            "Sammle 8 Tresore",
            "Recoge 8 Cajas Fuertes",
            "Pegue 8 cofres", 
            "اجمع 8 من الأمان",
            "Pick up 8 Safes",
            "Pick up 8 Safes", 
            "撿到 8 個保險箱", 
            "Thu thập 8 hộp bí ẩn" 
        },
        new List<string>()//69
        {
            "Roll 200 times on any train roof", 
            "Кувыркнуться 200 раз на крыше любого поезда", 
            "Roules 200 fois sur n'importe quel train",
            "Rolle 200 Mal auf den Dächern von Zügen",
            "Rueda en el suelo 200 veces en el techo de cualquier tren",
            "Role 200 vezes no teto de qualquer trem", 
            "تدحرج 200 مرة فوق أي قطار",
            "Roll 200 times on any train roof",
            "Roll 200 times on any train roof", 
            "在任意火車 上方翻滾 200 次", 
            "Cuộn chui 200 lần trên nóc tàu" 
        },
        new List<string>()//70
        {
            "Collect 15,000 diamonds", 
            "Собрать 15,000 бриллиантов", 
            "Collectes 15,000 diamants",
            "Sammle 15,000 Diamanten",
            "Consigue 15,000 diamantes",
            "Colete 15,000 diamantes", 
            "اجمع 15,000 ياقوتة",
            "Collect 15,000 diamonds",
            "Collect 15,000 diamonds", 
            "搜集 15,000 顆鑽石", 
            "Thu thập 15,000 kim cương" 
        },
        new List<string>()//71
        {
            "Collect 500,000 points", 
            "Набрать 500,000 очков (всего)", 
            "Collectes 500,000 points",
            "Sammle 500,000 Punkte",
            "Consigue 500,000 puntos",
            "Colete 500,000 pontos", 
            "اجمع 500,000 نقطة",
            "Collect 500,000 points",
            "Collect 500,000 points", 
            "得到 500,000 分", 
            "Đạt 500,000 điểm" 
        },
        new List<string>()//72
        {
            "Score 1500 points without collecting diamonds", 
            "Набрать 1500 очков, при этом не собрав ни одного бриллианта", 
            "Marques 1500 points",
            "Erreiche 1500 Punkte ohne Diamanten einzusammeln",
            "Consigue 1500 puntos sin recoger diamantes",
            "Marque 1500 pontos sem coletar diamantes", 
            "حقق 1500 نقطة بدون جمع الياقوت",
            "Score 1500 points without collecting diamonds",
            "Score 1500 points without collecting diamonds", 
            "得到 1500 分且沒有搜 集到任何鑽石", 
            "Đạt 1500 điểm mà không thu thập kim cương" 
        },
        new List<string>()//73
        {
            "Buy 6 Safes", 
            "Приобрести 6 Сейфов (купить в магазине)", 
            "Achètes 6 coffres-forts",
            "Kaufe 6 Tresore",
            "Compra 6 Cajas Fuertes",
            "Compre 6 cofres", 
            "اشتري 6 من الأمان",
            "Buy 6 Safes",
            "Buy 6 Safes", 
            "買 6 個保險箱", 
            "Mua 6 hộp bí ẩn" 
        },
        new List<string>()//74
        {
            "Use 15 Hoverboards in one run", 
            "Использовать 15 досок забег", 
            "Utilises 15 Hoverboards en une courses",
            "Benutze in einem Durchgang 15 Hoverboards",
            "Usa 15 Aeropatines en una carrera",
            "Use 15 Hoverboards em uma corrida", 
            "استخدم 15 هوفربورد في جولة واحدة",
            "Use 15 Hoverboards in one run",
            "Use 15 Hoverboards in one run", 
            "單趟使用 15 次漂浮滑板", 
            "Sử dụng 15 ván trượt trong 1 lần chạy" 
        },
        new List<string>()//75
        {
            "Use 5 Hoverboards without crashing", 
            "Использовать 5 доски (без столкновений!)", 
            "Utilises 5 Hoverboards sans t'écraser",
            "Benutze 5 Hoverboards ohne zu crashen",
            "Usa 5 Aeropatines sin chocar",
            "Use 5 Hoverboards sem se chocar", 
            "استخدم 5 هوفربورد بدون تصادم",
            "Use 5 Hoverboards without crashing",
            "Use 5 Hoverboards without crashing", 
            "使用 5 次漂浮滑板且 沒有撞到東西", 
            "Sử dụng 5 ván trượt mà không bị ngã" 
        },
        new List<string>()//76
        {
            "Crash into 15 barrels in one run", 
            "Врезаться а 15 бочек за один забег", 
            "Écrases-toi contre 15 tonneaux en une course",
            "Krache gegen 15 Fässer in einem Durchgang",
            "Choca contra 15 barriles en una carrera",
            "Se choque contra 15 barris em uma corrida", 
            "اصطدم في 15 برميل في جولة واحدة",
            "Crash into 15 barrels in one run",
            "Crash into 15 barrels in one run", 
            "撞到 15 次火藥桶", 
            "Va chạm với 15 thùng thuốc nổ trong 1 lần chạy" 
        },
        new List<string>()//77
        {
            "Stumble into 25 barriers", 
            "Столкнуться с 25-ю барьерами (прыгнуть на них сверху)", 
            "Trébuches sur 25 barrières",
            "Krache gegen 25 Barrieren",
            "Tropieza con 25 barriles",
            "Tropece em 25 barreiras", 
            "تعثر في 25 برميل",
            "Stumble into 25 barriers",
            "Stumble into 25 barriers", 
            "跌入 25 次障礙中", 
            "Trượt chân vào 25 hàng rào" 
        },
        new List<string>()//78
        {
            "Score 250,000 points in one run", 
            "Набрать 250,000 очков (за один забег)", 
            "Marques 250,000 points en une course",
            "Erreiche 250,000 Punkte in einem Durchgang",
            "Consigue 250,000 puntos en una carrera",
            "Marque 250,000 pontos em uma corrida", 
            "حقق 250,000 نقطة في جولة واحدة",
            "Score 250,000 points in one run",
            "Score 250,000 points in one run", 
            "單趟得分 250,000 分", 
            "Đạt 250,000 điểm trong 1 lần chạy" 
        },
        new List<string>()//79
        {
            "Stay in same lane for 25 seconds", 
            "Оставаться 25 секунд на одной и той же линии", 
            "Restes sur la même voie pendant 25 secondes",
            "Bleibe 25 Sekunden lang in der gleichen Spur",
            "Quédate en el mismo carril por 25 segundos",
            "Fique na mesma faixa por 25 segundos", 
            "ابق في نفس الخط لمدة 25 ثانية",
            "Stay in same lane for 25 seconds",
            "Stay in same lane for 25 seconds", 
            "停留在同 一軌道 25 秒", 
            "Giữ nguyên làn chạy trong 25 giây" 
        },
        new List<string>()//80
        {
            "Beat 1 Friend’s highscore", 
            "Побить результат друга из доски лидеров друзей", 
            "Dépasse le record de 1 ami",
            "Schlage den Rekord von 1 Freund",
            "Supera la Mejor Puntuación de 1 Amigo",
            "Bata o recorde de 1 Amigo", 
            "تخطي الرقم القياسي لصديق",
            "Beat 1 Friend’s highscore",
            "Beat 1 Friend’s highscore", 
            "打败 1 个朋友 的最 高分", 
            "Đánh bại 1 người bạn của bạn" 
        },
        new List<string>()//81
        {
            "Score 2000 Points without collecting any Diamonds", 
            "Набрать 2000 очков при этом не собрав ни одного бриллианта", 
            "Marque 2000 points sans ramasser aucun diamant",
            "Erziele 2000 Punkte, ohne Diamanten aufzulesen",
            "Consigue 2000 puntos sin recoger diamantes",
            "Marque 2000 Pontos sem coletar Diamantes", 
            "حقق 2000 نقطة بدون جمع الياقوت",
            "Score 2000 Points without collecting any Diamonds",
            "Score 2000 Points without collecting any Diamonds", 
            "不收集任 何钻 石得到 2000 分", 
            "Đạt 2000 điểm mà không thu thập kim cương" 
        },
        new List<string>()//82
        {
            "Score 5000 points without jumping", 
            "Набрать 5000 очков при этом не прыгнув ни раз", 
            "Marque 5000 points sans sauter",
            "Erziele 5000 Punkte ohne zu springen",
            "Consigue 5000 puntos sin saltar",
            "Marque 5000 Pontos sem pular", 
            "حقق 5000 نقطة بدون قفز",
            "Score 5000 points without jumping",
            "Score 5000 points without jumping", 
            "不跳跃 得到 5000 分", 
            "Đạt 5000 điểm mà không nhảy" 
        },
        new List<string>()//83
        {
            "Stay in same lane for 25 seconds", 
            "Продержаться 25 секунд в одном ряду", 
            "Reste sur la même piste pendant 25 secondes",
            "Bleib 25 Sekunden lang in der gleichen Spur",
            "Quédate en el mismo carril por 25 segundos",
            "Permaneça na mesma pista por 25 segundos", 
            "ابق في نفس الخط لمدة 25 ثانية",
            "Stay in same lane for 25 seconds",
            "Stay in same lane for 25 seconds", 
            "保持 在同一 条道 25 秒", 
            "Giữ nguyên làn chạy trong 25 giây" 
        },
        new List<string>()//84
        {
            "Ride on a speedboat 1 time", 
            "Прокатиться на гидроцикле 1 раз", 
            "Fais du hors-bord 1 fois",
            "Fahre 1 Mal mit einem Speedboot",
            "Monta en una lancha motora 1 vez",
            "Pegue a Lancha 1 vez", 
            "استخدم مركب السرعة لمرة واحدة",
            "Ride on a speedboat 1 time",
            "Ride on a speedboat 1 time", 
            "开一 次快艇", 
            "Điều khiển trên Speedboat 1 lần" 
        },
        new List<string>()//85
        {
            "Score 50,000 Points in one run", 
            "Набрать 50,000 очков в одном забеге", 
            "Marque 50,000 points en une course",
            "Erziele 50,000 Punkte in einer Runde",
            "Consigue 50,000 puntos en una carrera",
            "Marque 50,000 Pontos em uma corrida", 
            "حقق 50,000 نقطة في جولة واحدة",
            "Score 50,000 Points in one run",
            "Score 50,000 Points in one run", 
            "一次游戏 得到 50,000 分", 
            "Đạt 50,000 điểm trong 1 lần chạy" 
        },
        new List<string>()//86
        {
            "Pickup 50 power-ups", 
            "Собрать 50 пауэрапов (доски, джетпак, пылксос итд…)", 
            "Ramasse 50 bonus de puissance",
            "Sammle 50 Power-ups",
            "Recoge 50 power-ups",
            "Colete 50 power-ups", 
            "اجمع 50 من معززات القوة",
            "Pickup 50 power-ups",
            "Pickup 50 power-ups", 
            "收集 50 个加速", 
            "Thu thập 50 vật phẩm bất kỳ" 
        },
        new List<string>()//87
        {
            "Crash into 200 barrels", 
            "Врезаться в 200 бочек", 
            "Percute 200 tonneaux",
            "Crashe in 200 Fässer",
            "Choca contra 200 barriles",
            "Bata em 200 barris", 
            "اصطدم في 200 برميل",
            "Crash into 200 barrels",
            "Crash into 200 barrels", 
            "冲撞 200 个桶", 
            "Va chạm với 200 thùng thuốc nổ" 
        },
        new List<string>()//88
        {
            "Catch 10 drones", 
            "Поймать 10 дронов ", 
            "Attrape 10 drones",
            "Fange 10 Drohnen",
            "Atrapa 10 drones",
            "Pegue 10 drones", 
            "اجمع 10 طائرات",
            "Catch 10 drones",
            "Catch 10 drones", 
            "得到 10 个无人机", 
            "Pha hủy 10 Flycam" 
        },
        new List<string>()//89
        {
            "Win a bonus round 5 times", 
            "Пройти бонусный раунд 5 раз", 
            "Gagne une cartouche bonus 5 fois",
            "Gewinne 5 Mal eine Extrarunde",
            "Gana una ronda bonus 5 veces",
            "Ganhe uma rodada bônus 5 vezes", 
            "فز بجولة إضافية 5 مرات",
            "Win a bonus round 5 times",
            "Win a bonus round 5 times", 
            "赢 5 次奖励 回合", 
            "Hoàn thành 5 lần chạy trên con đường đền thờ" 
        },
        new List<string>()//90
        {
            "Ride on a speedboat 10 times", 
            "Прокатиться на гидроцикле 10 раз", 
            "Fais du hors-bord 10 fois",
            "Fahre 10 Mal mit einem Speedboot",
            "Monta en una lancha motora 10 veces",
            "Pegue a Lancha 10 vezes", 
            "استخدم مركب السرعة 10 مرات",
            "Ride on a speedboat 10 times",
            "Ride on a speedboat 10 times", 
            "开 10 次快艇", 
            "Điều khiển trên Speedboat 10 lần" 
        },
        new List<string>()//91
        {
            "Jump 2000 times", 
            "Прыгнуть 2000 раз", 
            "Saute 2000 fois",
            "Springe 2000 Mal",
            "Salta 2000 veces",
            "Pule 2000 vezes", 
            "اقفز 2000 مرة",
            "Jump 2000 times",
            "Jump 2000 times", 
            "跳跃 2000 次", 
            "Nhảy 2000 lần" 
        },
        new List<string>()//92
        {
            "Pick up 100 Super Sneakers", 
            "Подобрать 100 супер кроссовок", 
            "Ramasse 100 super baskets",
            "Sammle 100 Super-Sneaker",
            "Recoge 100 Super Zapatillas",
            "Colete 100 Tênis de Corrida", 
            "اجمع 100 حذاء خارق",
            "Pick up 100 Super Sneakers",
            "Pick up 100 Super Sneakers", 
            "收集 100 个超级 跑鞋", 
            "Thu thập 100 Giày Nhảy Cao" 
        },
        new List<string>()//93
        {
            "Roll 3000 times in total", 
            "Кувыркнуться 3000 раз", 
            "Roule 3000 fois en tout",
            "Mach insgesamt 3000 Mal eine Rolle vorwärts",
            "Rueda por el suelo 3000 veces en total",
            "Role 3000 vezes", 
            "تدحرج 3000 مرة",
            "Roll 3000 times in total",
            "Roll 3000 times in total", 
            "总共 翻滚 3000 次", 
            "Cuộn chui 3000 lần" 
        },
        new List<string>()//94
        {
            "Spend 2,000,000 Diamonds", 
            "Потратить 2,000,000 бриллиантов", 
            "Dépense 2,000,000 diamants",
            "Gib 2,000,000 Diamanten aus",
            "Gasta 2,000,000 Diamantes",
            "Gaste 2,000,000 Diamantes", 
            "انفق 2,000,000 ياقوتة",
            "Spend 2,000,000 Diamonds",
            "Spend 2,000,000 Diamonds", 
            "花掉 2,000,000 个钻石", 
            "Tiêu thụ 2,000,000 kim cương" 
        },
        new List<string>()//95
        {
            "Complete 5 Daily Challenges", 
            "Закончить 5 ежедневных заданий", 
            "Achève 5 défis quotidiens",
            "Absolviere 5 Tages-Herausforderungen",
            "Completa 5 Retos Diarios",
            "Complete 5 Desafios Diários", 
            "أكمل 5 من التحديات اليومية",
            "Complete 5 Daily Challenges",
            "Complete 5 Daily Challenges", 
            "完成 5 个每日 挑战", 
            "Hoàn thành 5 thử thách hàng ngày" 
        },
        new List<string>()//96
        {
            "Win a bonus round 15 times", 
            "Пройти бонусный раунд 15 раз", 
            "Gagne une cartouche bonus 15 fois",
            "Gewinne 15 Mal eine Bonusrunde",
            "Gana una ronda bonus 15 veces",
            "Ganhe uma rodada bônus 15 vezes", 
            "فز بجولة إضافية 15 مرة",
            "Win a bonus round 15 times",
            "Win a bonus round 15 times", 
            "赢 15 次奖 励回合", 
            "Chiến thắng con đường đền thờ 15 lần" 
        },
        new List<string>()//97
        {
            "Dodge 200 barrels", 
            "Увернуться от 200 бочек", 
            "Évite 200 tonneaux",
            "Weiche 200 Fässern aus",
            "Esquiva 200 barriles",
            "Desvie de 200 barris", 
            "تخطي 200 برميل",
            "Dodge 200 barrels",
            "Dodge 200 barrels", 
            "躲避 200 个桶", 
            "Tránh 200 thùng thuốc nổ" 
        },
        new List<string>()//98
        {
            "Score 60,000 points with a speedboat", 
            "Набрать 60,000 очков на гидроцикле", 
            "Marque 60,000 points avec un hors-bord",
            "Erziele 60,000 Punkte mit einem Speedboot",
            "Consigue 60,000 con una lancha motora",
            "Marque 60,000 pontos com a Lancha", 
            "حقق 60,000 نقطة باستخدام مركب السرعة",
            "Score 60,000 points with a speedboat",
            "Score 60,000 points with a speedboat", 
            "在快艇 上得到 60,000 分", 
            "Đạt 60,000 điểm với speedboat" 
        },
        new List<string>()//99
        {
            "Jump 300 times in one run", 
            "Прыгнуть 300 раз за один забег", 
            "Saute 300 fois en une course",
            "Springe in einem Durchgang 300 Mal",
            "Salta 300 times en una carrera",
            "Pule 300 vezes em uma corrida", 
            "اقفز 300 مرة في جولة واحدة",
            "Jump 300 times in one run",
            "Jump 300 times in one run", 
            "一次游戏 跳跃 300 次", 
            "Nhảy 300 lần trong 1 lần chạy" 
        },
        new List<string>()//100
        {
            "Buy 1 Wheel of Luck", 
            "Купить 1 Колесо Удачи", 
            "Achète 1 roue de la Fortune",
            "Kaufe 1 Glücksrad",
            "Compra 1 Ruleta de la Suerte",
            "Compre 1 Roda da Fortuna", 
            "أشتري عجلة حظ واحدة",
            "Buy 1 Wheel of Luck",
            "Buy 1 Wheel of Luck", 
            "购买 一个幸 运转盘", 
            "Mua 1 bánh xe may mắn" 
        },
        new List<string>()//101
        {
            "Crash into 500 barrels", 
            "Врезаться в 500 бочек", 
            "Percute 500 tonneaux",
            "Crashe in 500 Fässer",
            "Chocha contra 500 barriles",
            "Bata em 500 barris", 
            "اصطدم في 500 برميل",
            "Crash into 500 barrels",
            "Crash into 500 barrels", 
            "冲撞 500 个桶", 
            "Va chạm 500 thùng thuốc nổ" 
        },
        new List<string>()//102
        {
            "Score 10,000 points without jumping", 
            "Набрать 10,000 очков при этом ни разу не прыгнув", 
            "Marque 10,000 points sans sauter",
            "Erziele 10,000 Punkte, ohne zu springen",
            "Consigue 10,000 puntos sin saltar",
            "Marque 10,000 pontos sem pular", 
            "حقق 10,000 نقطة بدون قفز",
            "Score 10,000 points without jumping",
            "Score 10,000 points without jumping", 
            "不跳跃 得到 10,000 分", 
            "Đạt 10,000 điểm mà không nhảy" 
        },
        new List<string>()//103
        {
            "Spin Wheel of Luck 10 times", 
            "Прокрутить Колесо Удачи 10 раз", 
            "Fais tourner la roue de la Fortune 10 fois",
            "Drehe das Glücksrad 10 Mal",
            "Juega a la Ruleta de la Suerte 10 veces",
            "Gire a Roda da Fortuna 10 vezes", 
            "استخدم عجلة الحظ 10 مرات",
            "Spin Wheel of Luck 10 times",
            "Spin Wheel of Luck 10 times", 
            "转 10 次幸 运转盘", 
            "Quay bánh xe may mắn 10 lần" 
        },
        new List<string>()//104
        {
            "Pick up 20,000 Diamonds with a Speedboat", 
            "Собрать 20,000 Бриллиантов на гидроцикле", 
            "Ramasse 20,000 diamants avec un hors-bord",
            "Lese 20,000 Diamanten mit dem Speedboot auf",
            "Recoge 20,000 Diamantes con una lancha motora",
            "Colete 20,000 Diamantes com a Lancha", 
            "اجمع 20,000 ياقوتة باستخدام مركب السرعة",
            "Pick up 20,000 Diamonds with a Speedboat",
            "Pick up 20,000 Diamonds with a Speedboat", 
            "在快艇 上收集 20,000 个钻石", 
            "Thu thập 20,000 kim cương với Speedboat" 
        },
        new List<string>()//105
        {
            "Beat 2 Friend’s highscore", 
            "Побить результат двух друзей из доски лидеров", 
            "Dépasse le record de 2 amis",
            "Schlage den Rekord von 2 Freunden",
            "Supera la Mejor Puntuación de 2 Amigos",
            "Bata o recorde de 2 Amigos", 
            "تخطي الرقم القياسي لأثنين من أصدقائك",
            "Beat 2 Friend’s highscore",
            "Beat 2 Friend’s highscore", 
            "打败 2 个朋友 的最 高分", 
            "Đánh bại điểm số của 2 người bạn" 
        },
        new List<string>()//106
        {
            "Pickup 4000 Diamonds with a Vacuum", 
            "Собрать 4000 бриллиантов с помощью бриллиантового пылесоса", 
            "Ramasse 4000 diamants avec un aspirateur",
            "Lese 4000 Diamanten mit dem Vacuum-Magneten auf",
            "Recoge 4000 Diamantes con una Aspiradora",
            "Colete 4000 Diamantes com o Aspirador de Diamantes", 
            "اجمع 4000 ياقوتة باستخدام جامع الياقوت",
            "Pickup 4000 Diamonds with a Vacuum",
            "Pickup 4000 Diamonds with a Vacuum", 
            "用钻石 吸尘器 收集 4000 个钻石", 
            "Thu thập 4000 kim cương với Vacuum" 
        },
        new List<string>()//107
        {
            "Roll 250 times in one run", 
            "Кувыркнуться 250 раз за один забег", 
            "Roule 250 fois en une course",
            "Mach in einem Durchgang 250 Mal eine Rolle vorwärts",
            "Rueda por el suelo 250 veces en una carrera",
            "Role 250 vezes em uma corrida", 
            "تدحرج 250 مرة في جولة واحدة",
            "Roll 250 times in one run",
            "Roll 250 times in one run", 
            "一次 游戏 翻滚 250 次", 
            "Cuộn chui 250 lần trong 1 lần chạy" 
        },
        new List<string>()//108
        {
            "Get caught in first 5 seconds of run", 
            "Быть пойманным в первый 5 секунд забега", 
            "Fais-toi attraper dans les 5 premières secondes d’une course",
            "Lass dich in den ersten 5 Sekunden einer Runde fangen",
            "Se atrapado en los primeros 5 segundos de una carrera",
            "Seja capturado nos primeiros 5 segundos de uma corrida", 
            "يتم القبض عليك في أول 5 ثواني",
            "Get caught in first 5 seconds of run",
            "Get caught in first 5 seconds of run", 
            "在游戏 开始 5 秒内 被捕", 
            "Bị bắt trong 5 giây khi bắt đầu chạy" 
        },
        new List<string>()//109
        {
            "Score 80,000 Points in one run", 
            "Набрать 80,000 очков за один забег", 
            "Marque 80,000 points en une course",
            "Erziele 80,000 Punkte in einer Runde",
            "Consigue 80,000 puntos en una carrera",
            "Marque 80,000 pontos em uma corrida", 
            "اجمع 80,000 نقطة في جولة واحدة",
            "Score 80,000 Points in one run",
            "Score 80,000 Points in one run", 
            "一次游 戏得到 80,000 分", 
            "Đạt 80,000 điểm trong 1 lần chạy" 
        },
        new List<string>()//110
        {
            "Pick up 120 power-ups", 
            "Собрать 120 пауэрапов", 
            "Ramasse 120 bonus de puissance",
            "Lese 120 Power-ups auf",
            "Recoge 120 power-ups",
            "Colete 120 power-ups", 
            "اجمع 120 من معززات السرعة",
            "Pick up 120 power-ups",
            "Pick up 120 power-ups", 
            "收集 120 个加速", 
            "Thu thập 120 vật phẩm bất kỳ" 
        },
        new List<string>()//111
        {
            "Score 4000 Points without collecting any Diamonds", 
            "Набрать 4000 очков при этом не подобрав ниодного бриллианта", 
            "Marque 4000 points sans ramasser aucun diamant",
            "Erziele 4000 Punkte, ohne Diamanten aufzulesen",
            "Consigue 4000 puntos sin recoger Diamantes",
            "Marque 4000 pontos sem coletar Diamantes", 
            "حقق 4000 نقطة بدون جمع أي ياقوت",
            "Score 4000 Points without collecting any Diamonds",
            "Score 4000 Points without collecting any Diamonds", 
            "不收集 任何 钻石 得到 4000 分", 
            "Đạt 4000 điểm mà không sưu tập bất kỳ kim cương nào" 
        },
        new List<string>()//112
        {
            "Roll 500 times in the center lane", 
            "Кувыркнуться 500 раз в центральном ряду", 
            "Roule 500 fois sur la piste centrale",
            "Mach in der mittleren Spur 500 Mal eine Rolle vorwärts",
            "Rueda por el suelo 500 veces en el carril del centro",
            "Role 500 vezes na pista central", 
            "تدحرج 500 مرة في الخط الأوسط",
            "Roll 500 times in the center lane",
            "Roll 500 times in the center lane", 
            "在中 间道 翻滚 500 次", 
            "Cuộn chui 500 lần ở làn giữa" 
        },
        new List<string>()//113
        {
            "Collect 500 Diamonds with a Speedboat", 
            "Собрать 500 бриллиантов на гидроцикле", 
            "Ramasse 500 diamants avec un hors-bord",
            "Lese 500 Diamanten mit einem Speedboot auf",
            "Recoge 500 Diamantes con una lancha motora",
            "Colete 500 Diamantes com a Lancha", 
            "اجمع 500 ياقوتة باستخدام مركب السرعة",
            "Collect 500 Diamonds with a speedboat",
            "Collect 500 Diamonds with a speedboat", 
            "在快 艇上 收集 500 个钻石", 
            "Thu thập 500 kim cương với Speedboat" 
        },
        new List<string>()//114
        {
            "Complete 20 Daily Challenges", 
            "Закончить 20 ежеднвных челленджа", 
            "Achève 20 défis quotidiens",
            "Absolviere 20 Tages-Herausforderungen",
            "Completa 20 Retos Diarios",
            "Complete 20 Desafios Diários", 
            "اجمع 20 من التحديات اليومية",
            "Complete 20 Daily Challenges",
            "Complete 20 Daily Challenges", 
            "完成 20 个每日 挑战", 
            "Hoàn thành 20 thử thách hàng ngày" 
        },
        new List<string>()//115
        {
            "Dodge 4000 trains", 
            "Увернуться от 4000 поездов", 
            "Évite 4000 trains",
            "Weiche 4000 Zügen aus",
            "Esquiva 4000 trenes",
            "Desvie de 4000 Trens", 
            "تخطي 4000 برميل",
            "Dodge 4000 trains",
            "Dodge 4000 trains", 
            "躲避 4000 个火车", 
            "Tránh 4000 tàu hỏa" 
        },
        new List<string>()//116
        {
            "Pick up 500 Super Sneakers", 
            "Подобрать 500 Супер кроссовок", 
            "Ramasse 500 super baskets",
            "Sammle 500 Super-Sneaker",
            "Recoge 500 Super Zapatillas",
            "Colete 500 Tênis de Corrida", 
            "اجمع 500 من الأحذية الخارقة",
            "Pick up 500 Super Sneakers",
            "Pick up 500 Super Sneakers", 
            "收集 500 个超级 跑鞋", 
            "Thu thập 500 Giày Nhảy Cao" 
        },
        new List<string>()//117
        {
            "Pick up 6000 Diamonds with a Diamond Vacuum", 
            "Собрать 6000 бриллиантов при помощи пылесоса", 
            "Ramasse 6000 diamants avec un aspirateur à diamants",
            "Lese 6000 Diamanten mit einem Diamond Vacuum-Magneten auf",
            "Recoge 6000 Diamantes con una Aspiradora de Diamantes",
            "Colete 6000 Diamantes com um Aspirador de Diamantes", 
            "اجمع 6000 ياقوتة باستخدام جامع الياقوت",
            "Pick up 6000 Diamonds with a Diamond Vacuum",
            "Pick up 6000 Diamonds with a Diamond Vacuum", 
            "用钻 石吸尘 器收集 6000 个钻石", 
            "Thu thập 6000 kim cương với Diamond Vacuum" 
        },
        new List<string>()//118
        {
            "Pick up 4 Mystery Chests", 
            "Собрать 4 сундука-сюрприза", 
            "Ramasse 4 coffres mystères",
            "Hole dir 4 Schatztruhen",
            "Recoge up 4 Cofres Misteriosos",
            "Colete 4 Baús Misteriosos", 
            "اجمع 4 من صناديق الحظ",
            "Pick up 4 Mystery Chests",
            "Pick up 4 Mystery Chests", 
            "收集 4 个神秘 宝箱", 
            "Thu thập 4 Rương Bí Mật" 
        },
        new List<string>()//119
        {
            "Roll 100 times in one run", 
            "Кувыркнуться 100 раз за один забег", 
            "Roule 100 fois en une course",
            "Mach in einer Runde 100 Mal eine Rolle vorwärts",
            "Rueda por el suelo 100 veces en una carrera",
            "Role 100 vezes em uma corrida", 
            "تدحرج 100 مرة في جولة واحدة",
            "Roll 100 times in one run",
            "Roll 100 times in one run", 
            "一次 游戏 翻滚 100 次", 
            "Cuộn chui 100 lần trong 1 lần chạy" 
        },
        new List<string>()//120
        {
            "Collect 1000 Diamonds with a speedboat in one run", 
            "Собрать 1000 бриллиантов на гидроцикле за один забег", 
            "Ramasse 1000 diamants avec un hors-bord en une course",
            "Sammle in einem Durchgang 1000 Diamanten mit einem Speedbot ein ",
            "Recoge 1000 Diamantes con una lancha motora en una carrera",
            "Colete 1000 Diamantes com a Lancha em uma só corrida", 
            "اجمع 1000 ياقوتة باستخدام مركب السرعة في جولة واحدة",
            "Collect 1000 Diamonds with a speedboat in one run",
            "Collect 1000 Diamonds with a speedboat in one run", 
            "一次游 戏在快 艇上收集 1000 个钻石", 
            "Thu thập 1000 kim cương với Speedboat trong 1 lần chạy" 
        },
        new List<string>()//121
        {
            "Unlock 5 Speedboats", 
            "Разблокировать 5 гидроциклов", 
            "Débloque 5 hors-bord",
            "Schalte 5 Speedboote frei",
            "Desbloquea 5 Lanchas Motoras",
            "Desbloqueie 5 Lanchas", 
            "فتح 5 مركب سرعة",
            "Unlock 5 Speedboats",
            "Unlock 5 Speedboats", 
            "解锁 5 个快艇", 
            "Mở khóa 5 Speedboat" 
        },
        new List<string>()//122
        {
            "Pick up 30 Super Sneakers in one run", 
            "Подобрать 30 Супер кроссовок за один забег", 
            "Ramasse 30 super baskets en une course",
            "Sammle in einem Durchgang 30 Super-Sneaker",
            "Recoge 30 Super Zapatillas en una carrera",
            "Colete 30 Tênis de Corrida em uma corrida", 
            "اجمع 30 حذاء خارق في جولة واحدة",
            "Pick up 30 Super Sneakers in one run",
            "Pick up 30 Super Sneakers in one run", 
            "一次游 戏收集 30 个超级 跑鞋", 
            "Thu thập 30 Giày Nhảy Cao trong 1 lần chạy" 
        },
        new List<string>()//123
        {
            "Score 50,000 points in one run", 
            "Набрать 50,000 очков за один забег", 
            "Marque 50,000 points en une course",
            "Erziele 50,000 Punkte in einer Runde",
            "Consigue 50,000 puntos en una carrera",
            "Marque 50,000 pontos em uma corrida", 
            "حقق 50,000 نقطة في جولة واحدة",
            "Score 50,000 points in one run",
            "Score 50,000 points in one run", 
            "一次游戏 得到 50,000 分", 
            "Đạt 50,000 điểm trong 1 lần chạy" 
        },
        new List<string>()//124
        {
            "Spend 400,000 Diamonds", 
            "Потратить 400,000 бриллиантов", 
            "Dépense 400,000 diamants",
            "Gib 400,000 Diamanten aus",
            "Gasta 400,000 Diamantes",
            "Gaste 400,000 Diamantes", 
            "انفق 400,000 ياقوتة",
            "Spend 400,000 Diamonds",
            "Spend 400,000 Diamonds", 
            "花掉 400,000 个钻石", 
            "Tiêu thụ 400,000 kim cương" 
        },
        new List<string>()//125
        {
            "Bump into 8 trains in one run", 
            "Столкнуться с 8 поездами но не разбиться", 
            "Rentre dans 8 trains en une course",
            "Laufe in einer Runde in 8 Züge hinein",
            "Tropieza con 8 trenes en una carrera",
            "Bata contra 8 Trens em uma corrida", 
            "اصطدم في 8 قطارات في جولة واحدة",
            "Bump into 8 trains in one run",
            "Bump into 8 trains in one run", 
            "一次游 戏撞上 8 个火车", 
            "Va vào 8 tàu hỏa trong 1 lần chạy" 
        },
        new List<string>()//126
        {
            "Use 10 Hoverboards without crashing", 
            "Использовать 10 досок без столкновения", 
            "Utilise 10 hoverboards sans t’écraser",
            "Benutze 10 Hoverboards, ohne mit etwas zusammenzustoßen",
            "Usa 10 Aeropatines sin chocar",
            "Use 10 Hoverboards sem bater", 
            "استخدم 10 هوفربورد بدون تصادم",
            "Use 10 Hoverboards without crashing",
            "Use 10 Hoverboards without crashing", 
            "使用 10 个悬浮 滑板而 不坠毁", 
            "Sử dụng 10 ván bay mà không bị ngã" 
        },
        new List<string>()//127
        {
            "Use 5000 Hoverboards", 
            "Использовать 5000 досок", 
            "Utilise 5000 hoverboards",
            "Benutze 5000 Hoverboards",
            "Usa 5000 Aeropatines",
            "Use 5000 Hoverboards", 
            "استخدم 5000 هوفربورد",
            "Use 5000 Hoverboards",
            "Use 5000 Hoverboards", 
            "使用 5000 次悬浮 滑板", 
            "Sử dụng 5000 Ván Bay" 
        },
        new List<string>()//128
        {
            "Pickup 25 Powerups", 
            "Подобрать 25 пауэрапов", 
            "Ramasse 25 bonus de puissance",
            "Lese 25 Booster auf",
            "Recoge 25 Powerups",
            "Colete 25 Power-ups", 
            "اجمع 25 من معززات القوة",
            "Pickup 25 Powerups",
            "Pickup 25 Powerups", 
            "收集 25 个加速", 
            "Thu thập 25 vật phẩm bất kỳ" 
        },
        new List<string>()//129
        {
            "Stumble into 50 trains", 
            "Столкнуться с 50 поездами но не разбиться", 
            "Trébuche contre 50 trains",
            "Stolpere in 50 Züge",
            "Tropieza contra 50 trenes",
            "Bata contra 50 trens", 
            "تعثر في 50 قطار",
            "Stumble into 50 trains",
            "Stumble into 50 trains", 
            "撞上 50 个火车", 
            "Trượt chân vào 50 tàu hỏa" 
        },
        new List<string>()//130
        {
            "Pick up 20 Vacuums in one run", 
            "Подобрать 20 пылесосов за один забег", 
            "Ramasse 20 aspirateurs en une course",
            "Lese in einem Durchgang 20 Vakuum-Magneten auf",
            "Recoge 20 Aspiradoras en una carrera",
            "Colete 20 Aspiradores de Diamantes em uma corrida", 
            "اجمع 20 من جامع الياقوت من جولة واحدة",
            "Pick up 20 Vacuums in one run",
            "Pick up 20 Vacuums in one run", 
            "一次游 戏收集 20 个钻石 吸尘器", 
            "Thu thập 20 Vacuums trong 1 lần chạy" 
        },
        new List<string>()//131
        {
            "Buy 3 Mystery Boxes", 
            "Купить 3 сундука-сюрприза", 
            "Achète 3 boîtes mystères",
            "Kaufe 3 Schatztruhen",
            "Compra 3 Cajas Misteriosas",
            "Compre 3 Baús Misteriosos", 
            "اشتري 3 صناديق حظ",
            "Buy 3 Mystery Boxes",
            "Buy 3 Mystery Boxes", 
            "购买 3 个神秘 宝箱", 
            "Mua 3 Hộp Bí Ẩn" 
        },
        new List<string>()//132
        {
            "Pick up 240 Diamonds with a Magnet", 
            "Собрать 240 бриллиантов при помощи пылесоса магнита", 
            "Ramasse 240 diamants avec un aimant",
            "Hol dir 240 Diamanten mit einem Magneten",
            "Recoge 240 Diamantes con un Imán",
            "Colete 240 Diamantes com um Imã", 
            "اجمع 240 ياقوتة باستخدام المغناطيس",
            "Pick up 240 Diamonds with a Magnet",
            "Pick up 240 Diamonds with a Magnet", 
            "使用磁 铁收集 240 个钻石", 
            "Thu thập 240 kim cương với Nam Châm" 
        },
        new List<string>()//133
        {
            "Dodge 80 barriers", 
            "Увернуться от 80 бочек", 
            "Évite 80 barrières",
            "Umgehe 80 Hindernisse",
            "Esquiva 80 barreras",
            "Desvie de 80 barreiras", 
            "تخطي 80 برميل",
            "Dodge 80 barriers",
            "Dodge 80 barriers", 
            "躲避 80 个障碍", 
            "Tránh 80 hàng rào" 
        },
        new List<string>()//134
        {
            "Score 15,000 points without jumping", 
            "Набрать 15,000 очков при этом ни разу не прыгнув", 
            "Marque 15,000 points sans sauter",
            "Erziele 15,000 Punkte, ohne zu springen",
            "Consigue 15,000 puntos sin saltar",
            "Marque 15,000 pontos sem pular", 
            "حقق 15,000 نقطة بدون قفز",
            "Score 15,000 points without jumping",
            "Score 15,000 points without jumping", 
            "不跳跃 的情况 下得到 15,000 分", 
            "Đạt 15,000 điểm mà không nhảy" 
        },
        new List<string>()//135
        {
            "Spend 800,000 Diamonds", 
            "Потратить 800,000 бриллиантов", 
            "Dépense 800,000 diamants",
            "Gib 800,000 Diamanten aus",
            "Consigue 800,000 Diamantes",
            "Gaste 800,000 Diamantes", 
            "انفق 800,000 ياقوتة",
            "Spend 800,000 Diamonds",
            "Spend 800,000 Diamonds", 
            "花掉 800,000 个钻石", 
            "Tiêu thụ 800,000 kim cương" 
        },
        new List<string>()//136
        {
            "Pick up 30 Super Sneakers in one run", 
            "Подобрать 30 Супер кроссовок", 
            "Ramasse 30 super baskets en une course",
            "Sammle in einem Durchgang 30 Super-Sneaker",
            "Recoge 30 Super Zapatillas en una carrera",
            "Colete 30 Tênis de Corrida em uma só corrida", 
            "اجمع 30 حذاء خارق في جولة واحدة",
            "Pick up 30 Super Sneakers in one run",
            "Pick up 30 Super Sneakers in one run", 
            "一次游戏 中收集 30 个超级 跑鞋", 
            "Thu thập 30 Giày Nhảy Cao trong 1 lần chạy" 
        },
        new List<string>()//137
        {
            "Pick up 300 Jetpacks", 
            "Подобрать 300 джетпаков", 
            "Ramasse 300 jetpacks",
            "Lese 300 Jetpacks/Raketen-Rucksäcke auf",
            "Recoge 300 Mochilas Propulsoras",
            "Colete 300 Jetpacks", 
            "اجمع 300 من ادوات الطيران",
            "Pick up 300 Jetpacks",
            "Pick up 300 Jetpacks", 
            "收集 300 个喷气 背包", 
            "Thu thập 300 Thiết Bị Bay" 
        },
        new List<string>()//138
        {
            "Pick up 80 Mystery Chests", 
            "Подобрать 80 сундука-сюрприза", 
            "Ramasse 80 coffres mystères",
            "Hole dir 80 Schatzkisten",
            "Recoge 80 Cofres Misteriosos",
            "Colete 80 Baús Misteriosos", 
            "اجمع 80 من صناديق الحظ",
            "Pick up 80 Mystery Chests",
            "Pick up 80 Mystery Chests", 
            "收集 80 个神秘 宝箱", 
            "Thu thập 80 Hộp Bí Ẩn" 
        },
        new List<string>()//139
        {
            "Roll 200 times in the left lane", 
            "Кувыркнуться 200 раз в левом ряду", 
            "Roule 200 fois sur la piste de gauche",
            "Mach in der linken Spur 200 Mal eine Rolle vorwärts",
            "Rueda por el suelo 200 veces en el carril izquierdo",
            "Role 200 vezes na pista esqueda", 
            "تدحرج 200 مرة على الطريق الأيسر",
            "Roll 200 times in the left lane",
            "Roll 200 times in the left lane", 
            "在左道 翻滚 200 次", 
            "Cuộn chui 200 lần ở làn bên trái" 
        },
        new List<string>()//140
        {
            "Score 120,000 points in one run", 
            "Собрать 120,000 очков за один забег", 
            "Marque 120,000 points en une course",
            "Erziele 120,000 Punkte in einer Runde",
            "Consigue 120,000 puntos en una carrera",
            "Marque 120,000 pontos em uma corrida", 
            "حقق 120,000 نقطة في جولة واحدة ",
            "Score 120,000 points in one run",
            "Score 120,000 points in one run", 
            "一次游 戏得到 120,000 分", 
            "Đạt 120,000 điểm trong 1 lần chạy" 
        },
        new List<string>()//141
        {
            "Jump 10 times on a Speedboat", 
            "Прыгнуть 10 раз на гидроцикле", 
            "Saute 10 fois sur un hors-bord",
            "Springe 10 Mal auf ein Speedboot",
            "Salta 10 times en una Lancha Motora",
            "Pule 10 vezes com a Lancha", 
            "اقفز 10 مرات باستخدام مركب السرعة",
            "Jump 10 times on a Speedboat",
            "Jump 10 times on a Speedboat", 
            "在快艇 上跳跃 10 次", 
            "Nhảy 10 lần trên Speedboat" 
        },
        new List<string>()//142
        {
            "Collect 500,000 points", 
            "Набрать 500,000 очков", 
            "Ramasse 500,000 points",
            "Sammle 500,000 Punkte",
            "Consigue 500,000 puntos",
            "Colete 500,000 pontos", 
            "اجمع 500,000 نقطة",
            "Collect 500,000 points",
            "Collect 500,000 points", 
            "得到 500,000 分", 
            "Thu thập 500,000 điểm" 
        },
        new List<string>()//143
        {
            "Score 12,000 points without collecting Diamonds", 
            "Набрать 12,000 оков при этом ни подобрав ни одного бриллианта", 
            "Marque 12,000 points sans ramasser de diamants",
            "Erziele 12,000 Punkte, ohne Diamanten aufzulesen",
            "Consigue 12,000 puntos sin recoger Diamantes",
            "Marque 12,000 pontos sem coletar Diamantes", 
            "حقق 12,000 نقطة بدون جمع الياقوت ",
            "Score 12,000 points without collecting Diamonds",
            "Score 12,000 points without collecting Diamonds", 
            "不收集 钻石 得到 12,000 分", 
            "Đạt 12,000 điểm mà không thu thập kim cương" 
        },
        new List<string>()//144
        {
            "Buy 20 Wheel of Luck", 
            "Купить 20 Колеса Удачи", 
            "Achète 20 roues de la Fortune",
            "Kaufe 20 Glücksräder",
            "Compra 20 Ruletas de la Suerte",
            "Compre 20 Rodas da Fortuna", 
            "اشتري 20 عجلة حظ",
            "Buy 20 Wheel of Luck",
            "Buy 20 Wheel of Luck", 
            "购买 20 个幸运 轮盘", 
            "Mua 20 bánh xe may mắn" 
        },
        new List<string>()//145
        {
            "Buy 6 Mystery Chests", 
            "Купить 6 сундука-сюрприза", 
            "Achète 6 coffres mystères",
            "Kaufe 6 Schatztruhen",
            "Compra 6 Cofres Misteriosos",
            "Compre 6 Baús Misteriosos", 
            "اشتري 6 من صناديق الحظ",
            "Buy 6 Mystery Chests",
            "Buy 6 Mystery Chests", 
            "购买 6 个神秘 宝箱", 
            "Mua 6 hộp bí ẩn" 
        },
        new List<string>()//146
        {
            "Use 24 Hoverboards without crashing", 
            "Использовать 24 доски без столкновения", 
            "Utilise 24 hoverboards sans t’écraser",
            "Benutze 24 Hoverboards, ohne mit etwas zusammenzustoßen",
            "Use 24 Aeropatines sin chocas",
            "Use 24 Hoverboards sem bater", 
            "استخدم 24 هوفربورد بدون تصادم",
            "Use 24 Hoverboards without crashing",
            "Use 24 Hoverboards without crashing", 
            "使用 24 次悬浮 滑板而 不坠毁", 
            "Sử dụng 24 ván bay mà không bị ngã" 
        },
        new List<string>()//147
        {
            "Roll 300 times in the right lane", 
            "Кувыркнуться 300 раз в правом ряду", 
            "Roule 300 fois sur la piste de droite",
            "Mach in der rechten Spur 300 Mal eine Rolle vorwärts",
            "Rueda por el suelo 300 veces en el carril derecho",
            "Role 300 vezes na pista direita", 
            "تدحرج 300 مرة على الطريق الأيمن",
            "Roll 300 times in the right lane",
            "Roll 300 times in the right lane", 
            "在右道 翻滚 300 次", 
            "Cuộn chui 300 lần ở làn bên phải" 
        },
        new List<string>()//148
        {
            "Score 1,500,000 points in one run", 
            "Набрать 1,500,000 очков за один забег", 
            "Marque 1,500,000 points en une course",
            "Erziele 1,500,000 Punkte in einer Runde",
            "Consigue 1,500,000 puntos en una carrera",
            "Marque 1,500,000 pontos em uma corrida", 
            "حقق 1,500,000 نقطة في جولة واحدة",
            "Score 1,500,000 points in one run",
            "Score 1,500,000 points in one run", 
            "一次游 戏得到 1,500,000 分", 
            "Đạt 1,500,000 điểm trong 1 lần chạy" 
        },
        new List<string>()//149
        {
            "Dodge 100 barriers in one run", 
            "Увернуться от 100 препятствий за один забег", 
            "Évite 100 tonneaux en une course",
            "Umgehe 100 Hindernisse in einer Runde",
            "Esquiva 100 barreras en una carrera",
            "Desvie de 100 barreiras em uma corrida", 
            "تخطي 100 برميل في جولة واحدة",
            "Dodge 100 barriers in one run",
            "Dodge 100 barriers in one run", 
            "一次游戏 躲避 100 个障碍", 
            "Tránh 100 hàng rào trong 1 lần chạy" 
        },
        new List<string>()//150
        {
            "Roll 1000 times in total", 
            "Кувыркнуться 1000 раз", 
            "Roule 1000 fois en touts",
            "Mach insgesamt 1000 Mal eine Rolle vorwärts",
            "Rueda por el suelo 1000 veces en total",
            "Role 1000 vezes", 
            "تدحرج 1000 مرة",
            "Roll 1000 times in total",
            "Roll 1000 times in total", 
            "总共 翻滚 1000 次", 
            "Cuộn chui 1000 lần" 
        },
        new List<string>()//151
        {
            "Jump 70 times in one run", 
            "Прыгнуть 70 раз за один забег", 
            "Saute 70 fois en une course",
            "Springe 70 Mal in einem Durchgang",
            "Salta 70 veces en una carrera",
            "Pule 70 vezes em uma corrida", 
            "اقفز 70 مرة في جولة واحدة",
            "Jump 70 times in one run",
            "Jump 70 times in one run", 
            "一次游 戏跳跃 70 次", 
            "Nhảy 70 lần trong 1 lần chạy" 
        },
        new List<string>()//152
        {
            "Pick up 15 Super Sneakers in one run", 
            "Подобрать 15 супер-кроссовка за один забег", 
            "Ramasse 15 super baskets en une course",
            "Sammle in einem Durchgang 15 Super-Sneaker",
            "Recoge 15 Super Zapatillas en una carrera",
            "Colete 15 Tênis de Corrida em uma só corrida", 
            "اجمع 15 حذاء خارق في جولة واحدة",
            "Pick up 15 Super Sneakers in one run",
            "Pick up 15 Super Sneakers in one run", 
            "一次游 戏收集 15 个超级 跑鞋", 
            "Thu thập 15 Giày Nhảy Cao trong 1 lần chạy" 
        },
        new List<string>()//153
        {
            "Score 120,000 without any Powerups", 
            "Набрать 120,000 очков без пауэрапов", 
            "Marque 120,000 points, sans bonus de puissance",
            "Erziele 120,000 Punkte, ohne jegliche Power-ups",
            "Consigue 120,000, sin ningún Powerup",
            "Marque 120,000 sem Power-ups", 
            "حقق 120,000 نقطة بدون معززات القوة",
            "Score 120,000, without any Powerups",
            "Score 120,000, without any Powerups", 
            "不使用 加速， 得到 120,000 分", 
            "Đạt 120,000 điểm mà không thu thập vật phẩm nào" 
        },
        new List<string>()//154
        {
            "Stay in same lane for 20 seconds", 
            "Продержаться в одном ряду 20 секунд", 
            "Reste sur la même piste pendant 20 secondes",
            "Bleib 20 Sekunden lang in der gleichen Spur",
            "Quédate en el mismo carril por 20 segundos",
            "Fique na mesma pista por 20 segundos", 
            "ابق في نقس الخط لمدة 20 ثانية",
            "Stay in same lane for 20 seconds",
            "Stay in same lane for 20 seconds", 
            "保持在 同一道 20 秒", 
            "Giữa nguyên làn chạy trong 20 giây" 
        },
        new List<string>()//155
        {
            "Bump into 12 trains in one run", 
            "Столкнуться с 12 поездами но не разбиться", 
            "Rentre dans 12 trains en une course",
            "Renne in einer Runde in 12 Züge hinein",
            "Tropieza contra 12 trenes en una carrera",
            "Bata contra 12 Trens em uma só corrida", 
            "تعثر في 12 قطار في جولة واحدة",
            "Bump into 12 trains in one run",
            "Bump into 12 trains in one run", 
            "一次游 戏撞上 12 个火车", 
            "Va chạm với 12 tàu hỏa trong 1 lần chạy" 
        },
        new List<string>()//156
        {
            "Spend 900,000 Diamonds", 
            "Потратить 900,000 бриллиантов", 
            "Dépense 900,000 diamants",
            "Gib 900,000 Diamanten aus",
            "Gasta 900,000 Diamantes",
            "Gaste 900,000 Diamantes", 
            "انفق 900,000 ياقوته",
            "Spend 900,000 Diamonds",
            "Spend 900,000 Diamonds", 
            "花掉 900,000 个钻石", 
            "Tiêu thụ 900,000 kim cương" 
        },
        new List<string>()//157
        {
            "Score 2,000,000 points in one run", 
            "Набрать 2,000,000 очков за один забег", 
            "Marque 2,000,000 points en une course",
            "Erziele 2,000,000 Punkte in einer Runde",
            "Consigue 2,000,000 puntos en una carrera",
            "Marque 2,000,000 pontos em uma só corrida", 
            "حقق 2,000,000 نقطة في جولة واحدة",
            "Score 2,000,000 points in one run",
            "Score 2,000,000 points in one run", 
            "一次游 戏得到 2,000,000 分", 
            "Đạt 2,000,000 điểm trong 1 lần chạy" 
        },
        new List<string>()//158
        {
            "Score 25,000 points without jumping", 
            "Набрать 25,000 очков при этом не прыгнув ни один раз", 
            "Marque 25,000 sans sauter",
            "Erziele 25,000 Punkte, ohne zu springen",
            "Consigue 25,000 puntes sin saltar",
            "Marque 25,000 pontos sem pular", 
            "حقق 25,000 نقطة بدون قفز",
            "Score 25,000 points without jumping",
            "Score 25,000 points without jumping", 
            "不跳跃 得到 25,000 分", 
            "Đạt 25,000 điểm mà không nhảy" 
        },
        new List<string>()//159
        {
            "Stay in same lane for 30 seconds", 
            "Продержаться в одном ряду 30 секунд", 
            "Reste sur la même piste pendant 30 secondes",
            "Bleib 30 Sekunden lang in der gleichen Spur",
            "Quédate en el mismo carril por 30 segundos",
            "Fique na mesma pista por 30 segundos", 
            "ابق في نفس الخط لمدة 30 ثانية",
            "Stay in same lane for 30 seconds",
            "Stay in same lane for 30 seconds", 
            "保持在 同一道 30 秒", 
            "Giữ nguyên làn chạy trong 30 giây" 
        }
    };
}
