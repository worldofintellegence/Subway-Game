using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AllLanguages : MonoBehaviour {

    public static string gameName = "Best Surfers Run";
    public static List<Sprite> listIconLang = new List<Sprite>();
    public static List<Font> listFontLangA = new List<Font>();
    public static List<Font> listFontLangB = new List<Font>();

    public static List<bool> listSupport = new List<bool>()
    {
        true,
        true,
        true,
        true,
        true,
        true,
        true,
        true,
        true,
        true,
        true
    };

    public static List<string> listLanguage = new List<string>() { 
        "English",
        "Русский",
        "Français",
        "Deutsche",
        "Español",
        "Português",
        "عربى",
        "日本語",
        "한국어",
        "中文",
        "Tiếng Việt" 
    };

    public static List<string> listLangShort = new List<string>() { 
        "EN",
        "RU",
        "FR",
        "DE",
        "ES",
        "PT",
        "SA",
        "JP",
        "KR",
        "CN",
        "VN" 
    };

    //IN PAGE MENU GAME
    public static List<string> menuWaitMoment = new List<string>() 
    { 
        "Wait a moment...", 
        "Подождите минутку...",
        "Attendez un instant...",
        "Moment mal...", 
        "Espera un momento...", 
        "Espere um momento...", 
        "...انتظر لحظة", 
        "しばらくお 待ち 下さい…", 
        "잠시 기다립니다...", 
        "稍等片刻...", 
        "Chờ giây lát..." 
    };
    public static List<string> menuTapToPlay = new List<string>() 
    { 
        "Tap to play", 
        "Побежали!",
        "Appuyez pour jouer",
        "Tippen um zu spielen", 
        "Toque para jugar", 
        "Toque para jogar", 
        "انقر للعب", 
        "タップして プレイする", 
        "재생하려면 탭하세요", 
        "点击开始游戏", 
        "Táp để chơi" 
    };
    public static List<string> menuGetFree = new List<string>() 
    { 
        "Get free Keys, Hoverboard", 
        "Получить бесплатно Ключи, Доски",
        "Obtenez gratuitement des Clés, un Hoverboard",
        "Erhalten Sie kostenlose Schlüssel, Hoverboard", 
        "Obtener Llaves gratis, Hoverboard", 
        "Obtenhachaves grátis, Hoverboard", 
        "الحصول مجانا Keys، Hoverboard", 
        "無料の キー、 ホバーボードを 手に 入れる", 
        "무료 Keys, Hoverboard 받기", 
        "获得免费钥匙和悬浮滑板", 
        "Nhận miễn phí Chìa khóa, Ván bay" 
    };
    public static List<string> menuTitleWeekReward = new List<string>()
    {
        "weekly reward",
        "weekly reward",
        "weekly reward",
        "weekly reward",
        "weekly reward",
        "weekly reward",
        "weekly reward",
        "weekly reward",
        "weekly reward",
        "weekly reward",
        "thưởng hàng tuần"
    };
    public static List<string> menuDetailWeekReward = new List<string>()
    {
        "You get <color=#00F4FFFF>?</color> diamonds in the world top weekly contest.",
        "You get <color=#00F4FFFF>?</color> diamonds in the world top weekly contest.",
        "You get <color=#00F4FFFF>?</color> diamonds in the world top weekly contest.",
        "You get <color=#00F4FFFF>?</color> diamonds in the world top weekly contest.",
        "You get <color=#00F4FFFF>?</color> diamonds in the world top weekly contest.",
        "You get <color=#00F4FFFF>?</color> diamonds in the world top weekly contest.",
        "You get <color=#00F4FFFF>?</color> diamonds in the world top weekly contest.",
        "You get <color=#00F4FFFF>?</color> diamonds in the world top weekly contest.",
        "You get <color=#00F4FFFF>?</color> diamonds in the world top weekly contest.",
        "You get <color=#00F4FFFF>?</color> diamonds in the world top weekly contest.",
        "Bạn nhận được <color=#00F4FFFF>?</color> kim cương trong cuộc thi thê giới hàng tuần."
    };
    public static List<string> menuOn = new List<string>() 
    { 
        "On", 
        "Вкл",
        "Allumé",
        "An", 
        "Encendido",
        "Ligado", 
        "تشغيل",  
        "オン", 
        "켜기",
        "开启", 
        "Bật" 
    };
    public static List<string> menuOff = new List<string>() 
    { 
        "Off", 
        "Выкл", 
        "Éteint",
        "Aus", 
        "Apagado",
        "Desligado",
        "إيقاف",
        "オフ",
        "끄기",
        "关闭",
        "Tắt" 
    };
    public static List<string> menuLow = new List<string>() 
    { 
        "Low", 
        "Низко",
        "Bas", 
        "Niedrig",
        "Bajo", 
        "Baixo", 
        "منخفضة",
        "低い",  
        "낮은", 
        "低", 
        "Thấp" 
    };
    public static List<string> menuMedium = new List<string>() 
    { 
        "Medium", 
        "Средне",
        "Moyen",
        "Mittel", 
        "Medio",
        "Médio",
        "متوسطة",
        "中", 
        "중간", 
        "中等", 
        "Thường" 
    };
    public static List<string> menuHigh = new List<string>() 
    { 
        "High", 
        "Высоко", 
        "Haut",
        "Hoch", 
        "Alto",
        "Alto", 
        "عالية",
        "高", 
        "높음",
        "高",
        "Cao" 
    };
    public static List<string> menuFriend = new List<string>() 
    { 
        "Friend", 
        "Друг", 
        "Ami",
        "Freund",
        "Amigo",
        "Amigo",
        "صديق",
        "友達", 
        "친구",
        "朋友",
        "Bạn bè" 
    };
    public static List<string> menuCountry = new List<string>() 
    { 
        "Country", 
        "Страна", 
        "Pays",
        "Land",
        "País",
        "País",
        "بلد",
        "国",
        "국가",
        "国家",
        "Trong nước" 
    };
    public static List<string> menuApply = new List<string>() 
    { 
        "Apply", 
        "Применить",
        "Appliquer", 
        "Bewerben",
        "Aplicar", 
        "Aplicar", 
        "تطبيق", 
        "適用", 
        "대다", 
        "申请", 
        "Xác nhận" 
    };
    public static List<string> menuCancel = new List<string>() 
    { 
        "Cancel", 
        "Отмена", 
        "Annuler", 
        "Abbrechen",
        "Cancelar",
        "Cancelar",
        "إلغاء",
        "キャンセル", 
        "취소",
        "取消", 
        "Hủy bỏ" 
    };
    public static List<string> menuUpVideo = new List<string>() 
    { 
        "SHARE VIDEO", 
        "ВИДЕО БЕГА", 
        "SHARE VIDEO",
        "VIDEO TEILEN", 
        "SHARE VIDEO", 
        "SHARE VIDEO",
        "SHARE VIDEO",
        "ビデオを シェア", 
        "비디오 업로드",
        "分享视频", 
        "TẢI LÊN" 
    };
    public static List<string> menuMissions = new List<string>() 
    { 
        "MISSIONS", 
        "МИССИИ",
        "MISSIONS",
        "MISSIONEN",
        "MISIONES",
        "MISSÕES", 
        "المهام",
        "ミッション", 
        "임무", 
        "使命", 
        "NHIỆM VỤ" 
    };
    public static List<string> menuChallenge = new List<string>() 
    { 
        "CHALLENGE", 
        "ЧЕЛЛЕНДЖ", 
        "DEFI",
        "CHALLENGE", 
        "DESAFÍO", 
        "DESAFIO", 
        "التحدي",
        "チャレンジ", 
        "도전",
        "挑战", 
        "THỬ THÁCH" 
    };
    public static List<string> menuTitleMissions = new List<string>() 
    { 
        "Collect items", 
        "Собери предметы",
        "Récupérer des objets",
        "Gegenstände sammeln",
        "Recoger objetos", 
        "Coletar itens",
        "جمع العناصر", 
        "アイテムを 集める",
        "항목을 수집", 
        "收集物品",
        "Thu thập vật phẩm" 
    };
    public static List<string> menuTitleChallenge = new List<string>() 
    { 
        "Collect letters", 
        "Собери буквы",
        "Récupérer des lettres",
        "Buchstaben sammeln", 
        "Recoger cartas",
        "Coletar cartas",
        "جمع حروف", 
        "手紙を 集める",
        "편지 수집",
        "收集信件", 
        "Thu thập chữ cái" 
    };
    public static List<string> menuNoMissions = new List<string>() 
    { 
        "No missions", 
        "Нет миссий", 
        "Aucune mission",
        "Keine Missionen",
        "Sin misiones",
        "Sem missões",
        "لا مهام", 
        "ミッションなし", 
        "임무 없음", 
        "没有任务", 
        "Không có nhiệm vụ" 
    };
    public static List<string> menuNoChallenge = new List<string>() 
    { 
        "No challenge", 
        "Нет челленджов", 
        "Aucun défi",
        "Keine challenge",
        "Sin desafío", 
        "Sem desafio", 
        "لاتحدي",
        "チャレンジなし", 
        "도전 없음", 
        "没有挑战",
        "Không có thử thách" 
    };
    public static List<string> menuNoteMissions = new List<string>() 
    { 
        "While running, you will see different items on your way. Pick them up, if you collect the neccessary number, you will be rewarded with the gift as shown above.", 
        "Во время забега ты увидишь разные предметы, на таоём пути. Возьми их, и если соберёшь необходимое колличество предметов, то получишь достойное вознаграждение, как показано выше.", 
        "Pendant que tu courras, tu verras différents objets sur ta route. Ramasse-les, si tu en récupères un nombre suffisant, tu seras récompensé par le cadeau ci-dessus.", 
        "Während Sie laufen, werden Sie unterschiedliche Gegenstände sehen. Heben Sie diese auf. Wenn Sie genügend gesammelt haben, kriegen Sie das oben gezeigte Geschenk als Belohnung.", 
        "Mientras juega, verá diferentes objetos en el camino. Recójalos. Si recoge suficientes, será recompensado con un regalo como el indicado más arriba.",
        "Enquanto corre, você verá diferentes itens em seu caminho. Pegue-os, se você coletar o número necessário, você será recompensado com o presente, conforme mostrado acima.", 
        "أثناء الركض، سوف تري عناصر مختلفة فى طريقكَ. قم بأخذهم. إذا قمت بجمع الأرقام اللازمة، سوف تُكافئ بجائزة كم هو موضح.", 
        "走っている 間、 途中で 色々な アイテムが 見えます。 もしあなたが 必要な 数を 集めているならばそれらを 拾うと、 上記でみた 贈り 物とともに 報われるでしょう。", 
        "실행하는 동안, 당신은 방법에 표시 이상한 항목을 볼 수 있습니다. 그 (것)들을 데리십시오, 당신이 요구의 가득 차있는 수를 모으면, 당신은 위와 같이 선물로 보상 될 것이다.",
        "跑动时， 一路上您会看到 不同的物品。 将这些物品拿起， 如果您收集了 必要的数字， 你将得到如所显示 的礼物作为奖品。", 
        "Trong khi chạy, bạn sẽ nhìn thấy các vật phẩm kỳ lạ xuất hiện trên đường, Hãy nhặt chúng, nếu bạn thu thập đủ số lượng yêu cầu, bạn sẽ nhận được phần thưởng như ở trên." 
    };
    public static List<string> menuNoteChallenge = new List<string>() 
    { 
        "While running, you will see the alphabet shown on the road. Pick them up, if you collect the full letters in the word above, you will be rewarded with a random gift.", 
        "Во время забега на своём пути ты увидишь буквы. Собери все буквы в слове выше, и ты получишь в качестве вознаграждения случайный подарок.", 
        "Pendant que tu courras, tu verras l’alphabet apparaître sur la route. Ramasse-le, si tu récupères toutes les lettres du mot ci-dessus, tu recevras un cadeau aléatoire.", 
        "Während Sie laufen, werden Sie Buchstaben auf der Straße sehen. Hebe Sie diese auf. Wenn Sie die richtigen Buchstaben für das oben gezeigte Wort gesammelt haben, werden Sie mit einem Zufallsgeschenk belohnt.",
        "Mientras juega, verá el alfabeto mostrado en la carretera. Recójalo. Si recoge todas las letras de la palabra de arriba, será recompensado con un regalo al azar.", 
        "Enquanto corre, você verá o alfabeto na estrada. Pegue-os, se você coletar as todas as letras da palavra acima, você será recompensado com um presente aleatório.", 
        "أثناء الركض، سوف تري الحروف فى طريقك. قم بأخذها، إذا قمت بجمع حروف الكلمة الموجودة بالأعلي، سوف تحصل على جائزة تلقائية.", 
        "走っている 間、 道の 上に アルファベットが 見えます。 もしあなたが 上記の 言葉の 完全な 手紙を 集めているならば、 それらを 拾うと、 あなたは ランダムな 贈り 物とともに 報われるでしょう。",
        "실행하는 동안, 당신은 도로에 표시된 알파벳을 볼 수 있습니다. 위의 단어 전체 문자를 수집하는 경우를 들고, 당신은 임의의 선물로 보상 될 것이다.", 
        "跑动时， 您将会在道 路上看到显示的字母。 将它们收纳起来， 如果您收集上面 单词中的完整字母， 您会得到 一个随机的礼 物作为奖励。", 
        "Trong khi chạy, bạn sẽ nhìn thấy các chữ cái xuất hiện trên đường, Hãy nhặt chúng, nếu bạn nhặt đủ bộ chữ trong từ ở trên, bạn sẽ nhận được một phần thường ngẫu nhiên." 
    };
    public static List<string> menuTopRun = new List<string>() 
    { 
        "TOP RUN", 
        "ЛИДЕРЫ", 
        "TOP RUN",
        "BESTER",
        "TOP RUN", 
        "TOP RUN", 
        "أعلي ركض",
        "トップラン", 
        "탑 러닝", 
        "最高路程", 
        "XẾP HẠNG" 
    };
    public static List<string> menuHero = new List<string>() 
    { 
        "HERO", 
        "ГЕРОЙ",
        "HÉROS",
        "HELD",
        "HÉROE",
        "HERÓI", 
        "بطل",
        "ヒーロー", 
        "영웅",
        "英雄",
        "TÔI" 
    };
    public static List<string> menuShop = new List<string>() 
    { 
        "SHOP", 
        "МАГАЗ",
        "SHOP",
        "SHOP", 
        "TIENDA",
        "LOJA", 
        "المتجر",
        "ショップ", 
        "가게", 
        "商店",
        "MUA" 
    };
    public static List<string> menuHighScore = new List<string>() 
    { 
        "HIGH SCORE", 
        "HIGH SCORE",
        "HIGH SCORE",
        "HIGH SCORE", 
        "HIGH SCORE",
        "HIGH SCORE", 
        "HIGH SCORE",
        "HIGH SCORE", 
        "HIGH SCORE", 
        "HIGH SCORE", 
        "ĐIỂM CAO" 
    };
    public static List<string> menuSpin = new List<string>() 
    { 
        "SPIN", 
        "КРУТИ", 
        "SPIN",
        "SPIN", 
        "SPIN",
        "SPIN", 
        "SPIN", 
        "SPIN",
        "SPIN",
        "SPIN",
        "QUAY" 
    };
    public static List<string> menuPlay = new List<string>() 
    { 
        "PLAY", 
        "ИГРАТЬ",
        "JOUER",
        "SPIELEN",
        "JUGAR",
        "JOGAR",
        "العب",
        "プレイ", 
        "놀이",
        "玩",
        "CHƠI" 
    };
    public static List<string> menuGetHoverboard = new List<string>() 
    { 
        "GET HOVERBOARD", 
        "КУПИТЬ ДОСКУ", 
        "OBTENIR L’HOVERBOARD", 
        "HOVERBOARD HOLEN", 
        "OBTENER HOVERBOARD",
        "OBTER HOVERBOARD", 
        "HOVERBOARD الحصول على", 
        "ホバーボードを ゲットする", 
        "받기 HOVERBOARD", 
        "得到悬浮滑板", 
        "LẤY VÁN BAY" 
    };
    public static List<string> menuGetKeys = new List<string>() 
    { 
        "GET KEYS", 
        "КУПИТЬ КЛЮЧИ",
        "OBTENIR DES CLÉS",
        "SCHLÜSSEL HOLEN", 
        "OBTENER LLAVES", 
        "OBTER CHAVES", 
        "الحصول على المفاتيح", 
        "キーを ゲットする", 
        "받기 열쇠", 
        "得到钥匙", 
        "LẤY CHÌA KHÓA" 
    };
    public static List<string> menuShare = new List<string>() 
    { 
        "SHARE", 
        "ПОДЕЛИСЬ",
        "PARTAGER", 
        "TEILEN", 
        "COMPARTIR",
        "COMPARTILHAR", 
        "مشاركة", 
        "シェア", 
        "공유하기",
        "分享", 
        "CHIA SẺ" 
    };
    public static List<string> menuButtonShare = new List<string>() 
    { 
        "SHARE NOW", 
        "ПОДЕЛИСЬ", 
        "PARTAGER", 
        "TEILEN", 
        "COMPARTIR",
        "COMPARTIR", 
        "مشاركة الأن", 
        "今 シェアする", 
        "공유하기 지금",
        "分享按钮", 
        "CHIA SẺ" 
    };
    public static List<string> menuNoteShare = new List<string>() 
    {
        "Share this game with your friends on your Facebook page to unlock <color=green>Louis</color> for free.",
        "Расскажи друзьям об игре на своей странице в Фейсбуке, чтобы бесплатно разблокировать <color=green>Louis</color>.",
        "Partage ce jeu sur Facebook pour débloquer le personnage <color=green>Louis</color> gratuitement.",
        "Teilen sie dieses Spiel mit Ihren Freunden auf Facebook, um <color=green>Louis</color> Charakter gratis freizuschalten.",
        "Comparta este juego con sus amigos de Facebook para desbloquear el personaje <color=green>Louis</color> gratis.",
        "Compartilhe este jogo com seus amigos do Facebook para desbloquear o personagem <color=green>Louis</color> gratuitamente.",
        "مشاركة هذه اللعبة لأصدقائك على فيسبوك للحصول على لويس<color=green>Louis</color>مجانا.",
        "Facebook でお 友達にこの ゲームを シェアして、 キャラクター <color=green>ルイス</color> を 無料で ロック 解除する。",
        "무료 <color=green>Louis</color> 캐릭터의 잠금을 해제하려면 Facebook 에서이 게임을 공유하십시오.",
        "在您的面子 书页面上与您 的朋友分享此游戏， 以免费解锁 <color=green>Louis</color>。",
        "Chia sẻ trò chơi này trên Facebook của bạn để mở khóa nhân vật <color=green>Louis</color> miễn phí."
    };
    public static List<string> menuInvite = new List<string>() 
    { 
        "INVITE", 
        "ПРИГЛАСИТЬ",
        "INVITER", 
        "EINLADEN", 
        "INVITACIÓN",
        "CONVITE", 
        "أدعو", 
        "招待", 
        "초대", 
        "邀请", 
        "MỜI BẠN BÈ" 
    };
    public static List<string> menuButtonInvite = new List<string>() 
    { 
        "INVITE NOW", 
        "ПРИГЛАСИТЬ", 
        "INVITER", 
        "EINLADEN", 
        "INVITE", 
        "INVITE",
        "أدعو الآن", 
        "今招待する", 
        "초대 지금", 
        "邀请按钮", 
        "MỜI NGAY" 
    };
    public static List<string> menuNoteInvite = new List<string>() 
    {
        "Send out invitations to your friends <color=green>(" + Modules.coinBonusInvite + " diamonds/ friend)</color>. The more friends you invite, the more diamonds you will get.", 
        "Отправляйте приглашения своим друзьям <color=green>(" + Modules.coinBonusInvite + " БРИЛЛИАНТОВ/ друг)</color>. Чем больше друзей пригласишь, тем больше получишь БРИЛЛИАНТОВ.", 
        "Envoie des invitations à tes amis <color=green>(" + Modules.coinBonusInvite + " pièces/ ami)</color>. Plus tu invitesd'amis, plus tu aurasde pièces de monnaie.", 
        "Senden Sie Einladungen an ihre Freunde <color=green>(" + Modules.coinBonusInvite + " Münzen/ Freund)</color>. Je mehr Freunde Sie einladen, desto mehr Münzen erhalten Sie.", 
        "Envíe invitaciones a sus amigos <color=green>(" + Modules.coinBonusInvite + " diamantes/ amigo)</color>. Cuantos más amigos invite, más diamantes recibirá.", 
        "Envie convites para seus amigos <color=green>(" + Modules.coinBonusInvite + " diamantes/ amigo)</color>. Quanto mais amigos você convidar,mais diamantes você receberá.", 
        "إرسال دعوات إلى أصدقائك <color=green>(" + Modules.coinBonusInvite + " قطعة نقدية /صديق)</color>. يمكنك دعوة المزيد من الأصدقاء، وسوف تحصل علي المزيد من النقود.", 
        "友達に 招待状を 送る <color = green>（"+ Modules.coinBonusInvite +"ダイアモンド/ 友達）</ color> 友達を 招待すればするほど、 多くの ダイアモンドを 手に 入れられます。",
        "친구 <color=green>(" + Modules.coinBonusInvite + " 동전 / 친구)</color> 에게 초대장을 보냅니다. 당신은 더 많은 친구를 초대, 당신은 더 많은 동전 것입니다.", 
        "发送邀请 给您的朋友 <color=green>（" + Modules.coinBonusInvite + " 钻石/ 朋友）</color>。您邀请的朋友越多， 你得到的钻石越多。", 
        "Gửi lời mời cho bạn bè <color=green>(" + Modules.coinBonusInvite + " diamonds/ bạn bè)</color>. Bạn mời càng nhiều, bạn càng có nhiều diamonds." 
    };
    public static List<string> menuRate = new List<string>() 
    { 
        "REVIEW", 
        "ОЦЕНКА",
        "NOTER", 
        "BEWERTEN", 
        "OPINIONES",
        "OPINIÃO",
        "مراجعة", 
        "レビュー", 
        "리뷰", 
        "回顾",
        "XẾP HẠNG" 
    };
    public static List<string> menuButtonRate = new List<string>() 
    { 
        "RATE", 
        "ОЦЕНИТЬ", 
        "NOTER", 
        "BEWERTEN", 
        "PUNTUAR",
        "AVALIAÇÃO",
        "تقيّم", 
        "レート", 
        "리뷰",
        "回顾按钮", 
        "XẾP HẠNG" 
    };
    public static List<string> menuNoteRate = new List<string>() 
    {
        "<color=green>Rate</color> and review.",
        "<color=green>Оценить</color> игру.", 
        "Aidez-nous à <color=green>améliorer</color> le jeu.", 
        "Helfen uns, indem Sie das Spiel <color=green>Bewerten</color>.",  
        "Ayúdenos a <color=green>mejorar</color> el juego.", 
        "Nos ajude a <color=green>melhorar</color> o jogo.", 
        "مساعدتنا على <color=green>تحسين</color>اللعبة.", 
        "<color=green>レート</color> と レビュー",
        "우리가 게임을 <color=green>개선</color> 할 수 있도록 도와주세요.", 
        "<color=green>评价</color> 及回顾。",
        "<color=green>Đánh giá</color> và xếp hạng trò chơi." 
    };
    public static List<string> menuNoteHoverboard = new List<string>() 
    { 
        "Click the button below to get free <color=green>HOVERBOARD</color>.", 
        "Жми ниже, чтобы получить бесплатные <color=green>ДОСКИ</color>.", 
        "Clique sur le bouton ci-dessous pour obtenir un <color=green>HOVERBOARD</color> gratuit.",
        "Klicken Sie auf die Schaltfläche unten, um ein kostenloses <color=green>HOVERBOARD</color> zu erhalten.",
        "Haga clic en el botón de abajo y obtenga <color=green>HOVERBOARD</color> gratis.", 
        "Clique no botão abaixo para obter <color=green>HOVERBOARD</color> grátis.",
        "انقر فوق الزر أدناه للحصول علي مجاناً<color=green>HOVERBOARD</color>.", 
        "下記 ボタンを クリックして、 <color=green>ホバーボード</color> を 無料で ゲットする", 
        "무료 <color=green>HOVERBOARD</color> 를 받으려면 아래 버튼을 클릭하십시오.", 
        "点击下面的 按钮以获取 免费的<color=green>悬浮滑板</color>.",
        "Ấn nút phía dưới để nhận miễn phí <color=green>VÁN BAY</color>." 
    };
    public static List<string> menuNoteKeys = new List<string>() 
    { 
        "Click the button below to get free <color=orange>KEYS</color>.", 
        "Жми, чтобы получить бесплатные <color=orange>КЛЮЧИ</color>.",
        "Clique sur le bouton ci-dessous pour obtenir des <color=orange>CLÉS</color> gratuites.",
        "Klicken Sie auf die Schaltfläche unten, um gratis <color=orange>SCHLÜSSEL</color> zu erhalten.", 
        "Haga clic en el botón de abajo para obtener <color=orange>LLAVES</color> gratis.", 
        "Clique no botão abaixo para obter <color=orange>CHAVES</color> grátis.", 
        "انقر على الزر أدناه للحصول على <color=orange>KEYS</color>مجانية.", 
        "下記 ボタンを クリックして、 <color=orange>キー</color> を 無料で ゲット", 
        "무료 <color=orange>KEYS</color> 받으려면 아래 버튼을 클릭하십시오.", 
        "点击下面的 按钮以获取 免费的<color=orange>钥匙</color>.",
        "Ấn nút phía dưới để nhận miễn phí <color=orange>CHÌA KHÓA</color>." 
    };
    public static List<string> menuPleaseWait = new List<string>() 
    { 
        "Please wait!", 
        "Подождите!", 
        "Veuillez patienter!", 
        "Bitte warten!", 
        "¡Espere!",
        "Esperar!", 
        "رجاء الأنتظار!", 
        "お 待ちください！", 
        "기다려주세요!", 
        "请稍候！", 
        "Vui lòng chờ!" 
    };
    public static List<string> menuClickView = new List<string>() 
    { 
        "Click view", 
        "Нажмите", 
        "Clique vue",
        "Klickansicht", 
        "Click ver",
        "Clique vista", 
        "عرض الآن", 
        "クリックビュー", 
        "보기를 클릭",
        "点击查看",
        "Kích xem" 
    };
    public static List<string> menuSetting = new List<string>() 
    { 
        "SETTINGS", 
        "НАСТРОЙКИ", 
        "RÉGLAGES", 
        "SETTINGS",
        "AJUSTE",
        "SETTINGS", 
        "إعدادات", 
        "設定", 
        "놓음", 
        "设置",
        "CÀI ĐẶT" 
    };
    public static List<string> menuLanguage = new List<string>() 
    { 
        "LANGUAGE", 
        "ЯЗЫК",
        "LANGUE",
        "SPRACHE", 
        "IDIOMA",
        "IDIOMA", 
        "اللغة", 
        "言語", 
        "언어",
        "语言",
        "NGÔN NGỮ" 
    };
    public static List<string> menuBGMusic = new List<string>() 
    { 
        "BACKGROUND MUSIC", 
        "ФОНОВАЯ МУЗЫКА",
        "MUSIQUE DE FOND", 
        "HINTERGRUNDMUSIK",
        "MÚSICA DE FONDO", 
        "MÚSICA DE FUNDO", 
        "الموسيقي", 
        "BGM", 
        "배경 음악", 
        "背景音乐", 
        "ÂM NHẠC NỀN" 
    };
    public static List<string> menuActionSound = new List<string>() 
    { 
        "GAME SOUNDS", 
        "ЗВУКИ В ИГРЕ", 
        "AUTRES MUSIQUE",
        "SPIELGERÄUSCHE", 
        "OTRA MÚSICA", 
        "SONS DO JOGO",
        "أصوات", 
        "ゲームサウンド", 
        "기타 음악",
        "游戏声音", 
        "ÂM THANH KHÁC" 
    };
    public static List<string> menuLevelEffect = new List<string>() 
    { 
        "LEVEL OF EFFECTS", 
        "УРОВЕНЬ ЭФФЕКТОВ", 
        "NIVEAU D'EFFETS",
        "NIVEAU DER EFFEKTE",
        "NIVEL DE EFECTOS",
        "NÍVEL DE EFEITOS",
        "مستوي المؤثرات", 
        "効果の レベル", 
        "효과 수준", 
        "影响的水平", 
        "MỨC ĐỘ HIỆU ỨNG" 
    };
    public static List<string> menuSkyEffect = new List<string>() 
    { 
        "SKY EFFECTS", 
        "ЭФФЕКТЫ НЕБА", 
        "EFFETS DU CIEL",
        "HIMMELEFFEKTE",
        "EFECTOS CIELO",
        "EFEITOS DO CÉU",
        "مؤثرات السماء", 
        "スカイエフェクト", 
        "하늘 효과",
        "天空效应", 
        "HIỆU ỨNG BẦU TRỜI" 
    };
    public static List<string> menuSensitivity = new List<string>() 
    { 
        "SENSITIVITY", 
        "ЧУВСТВИТЕЛЬНОСТЬ", 
        "SENSIBILITÉ", 
        "EMPFINDLICHKEIT", 
        "SENSIBILIDAD", 
        "SENSIBILIDADE", 
        "الحساسية", 
        "感度", 
        "감광도", 
        "敏感度", 
        "ĐỘ NHẠY CẢM" 
    };
    public static List<string> menuSpeedJump = new List<string>() 
    { 
        "JUMP UP SPEED", 
        "СКОРОСТЬ ПРЫЖКА",
        "VITESSE DE SAUT",
        "SPRUNG-GESCHWINDIGKEIT", 
        "SALTO DE VELOCIDAD",
        "VELOCIDADE DE SALTO", 
        "سرعة القفز", 
        "ジャンプスピード", 
        "점프 업 속도",
        "跳动速度", 
        "TỐC ĐỘ NHẢY" 
    };
    public static List<string> menuCompititor = new List<string>() 
    { 
        "COMPETITOR\n(Need to reset)", 
        "СОПЕРНИК\n(Сбросить игру)", 
        "CONCURRENT\n(Réinitialiser)",
        "GEGNER\n(Reset-Spiel)",
        "COMPETIDOR\n(Debe Reset)", 
        "COMPETIDOR\n(Reiniciar)", 
        "المنافس\n(إعادة تعيين)",
        "競争者\n（リセットが 必要）", 
        "경쟁사 (재설정 필요)", 
        "竞争对手\n（需要重置）",
        "ĐỐI THỦ\n(Khởi động lại)" 
    };
    public static List<string> menuCurvedWorld = new List<string>() 
    { 
        "CURVED WORLD", 
        "КРИВОЙ МИР", 
        "MONDE COURBE", 
        "RUNDE WELT",
        "MUNDO CURVADO", 
        "MUNDO CURVADO", 
        "العالم المنحني", 
        "湾曲した 世界", 
        "곡선 세계", 
        "弯曲世界", 
        "ĐỊA HÌNH CONG" 
    };
    public static List<string> menuPrivacyPolicy = new List<string>() 
    { 
        "PRIVACY POLICY", 
        "ПОЛИТИКА КОНФИДЕНЦИАЛЬНОСТИ", 
        "POLITIQUE DE CONFIDENTIALITE", 
        "DATENSCHUTZERKLÄRUNG",
        "POLÍTICA PRIVACIDAD", 
        "POLÍTICA DE PRIVACIDADE", 
        "سياسة الخصوصية", 
        "個人情報保護方針",  
        "개인 정보 정책", 
        "隐私政策", 
        "CHÍNH SÁCH BẢO MẬT" 
    };
    public static List<string> menuQuitGame = new List<string>() 
    { 
        "QUIT GAME", 
        "ПОКИНУТЬ ИГРУ", 
        "QUITTER LE JEU", 
        "SPIEL BEENDEN",
        "SALIR DEL JUEGO", 
        "SAIR DO JOGO", 
        "الخروج من اللعبة", 
        "ゲームを 終了", 
        "게임 나가기", 
        "退出游戏", 
        "THOÁT TRÒ CHƠI" 
    };
    public static List<string> menuTitleOnline = new List<string>()
    {
        "Challenge ONLINE",
        "Брошен вызов Онлайн",
        "Défi EN LIGNE",
        "Herausforderung ONLINE",
        "Desafío ONLINE",
        "Desafio ONLINE",
        "オンラインで 挑戦",
        "Challenge ONLINE",
        "Challenge ONLINE",
        "退出游戏",
        "Thử thách ONLINE"
    };
    public static List<string> menuDetailsOnline = new List<string>()
    {
        "Click the <color=yellow>ONLINE</color> button in the Menu to join the match.",
        "Жми на кнопку <color=yellow>ОНЛАЙН</color> в главном меню чтобы принять вызов.",
        "Clique sur le bouton <color=yellow>EN LIGNE</color> dans le menu pour rejoindre un match.",
        "Klicken Sie auf den <color=yellow>ONLINE</color> Button im Menü um dem Spiel beizutreten.",
        "Click el botón <color=yellow>ONLINE</color> en el Menú para unirse a la partida.",
        "Click no botão <color=yellow>ONLINE</color> no Menu para juntar-se a partida.",
        "Click the <color=yellow>ONLINE</color> button in the Menu to join the match.",
        "メニューの <color=yellow>ONLINE</color> ボタンを クリックして ゲームに 参加する",
        "Click the <color=yellow>ONLINE</color> button in the Menu to join the match.",
        "点击 <color=yellow>菜单上的线上</color> 按钮以加 入竞赛。",
        "Kích nút <color=yellow>ONLINE</color> ở ngoài Menu để tham gia thi đấu Online."
    };

    //FACEBOOK SHARE
    public static List<string> menuInforDetail = new List<string>() 
    { 
        gameName + " is a fun, addicting, endless running game.", 
        gameName + " is a fun, addicting, endless running game.", 
        gameName + " is a fun, addicting, endless running game.", 
        gameName + " is a fun, addicting, endless running game.", 
        gameName + " is a fun, addicting, endless running game.", 
        gameName + " is a fun, addicting, endless running game.", 
        gameName + " is a fun, addicting, endless running game.", 
        gameName + " is a fun, addicting, endless running game.", 
        gameName + " is a fun, addicting, endless running game.", 
        gameName + " is a fun, addicting, endless running game.", 
        gameName + " rat vui. hap dan, mot the loai tro choi chay vo han." 
    };
    //I gained XXX point, in Fruntastic Squad Run Game, what about you?
    public static List<string> menuInforStart = new List<string>() 
    { 
        "I scored", 
        "I scored", 
        "I scored", 
        "I scored",
        "I scored",
        "I scored", 
        "I scored", 
        "I scored", 
        "I scored", 
        "I scored",
        "Toi dat duoc" 
    };
    public static List<string> menuInforEnd = new List<string>() 
    { 
        "points, in " + gameName + ", what about you?", 
        "points, in " + gameName + ", what about you?", 
        "points, in " + gameName + ", what about you?", 
        "points, in " + gameName + ", what about you?", 
        "points, in " + gameName + ", what about you?", 
        "points, in " + gameName + ", what about you?", 
        "points, in " + gameName + ", what about you?", 
        "points, in " + gameName + ", what about you?", 
        "points, in " + gameName + ", what about you?", 
        "points, in " + gameName + ", what about you?", 
        "diem, trong tro choi " + gameName + ", con ban thi sao?" 
    };
    public static List<string> menuMessageInvite = new List<string>() 
    { 
        "Come play this great game!", 
        "Come play this great game!", 
        "Come play this great game!", 
        "Come play this great game!", 
        "Come play this great game!",
        "Come play this great game!", 
        "Come play this great game!", 
        "Come play this great game!", 
        "Come play this great game!", 
        "Come play this great game!", 
        "Hay thu va trai nghiem!" 
    };
    public static List<string> menuTitleInvite = new List<string>() 
    { 
        "INVITE FRIENDS", 
        "INVITE FRIENDS", 
        "INVITE FRIENDS",
        "INVITE FRIENDS",
        "INVITE FRIENDS", 
        "INVITE FRIENDS", 
        "INVITE FRIENDS", 
        "INVITE FRIENDS", 
        "INVITE FRIENDS", 
        "INVITE FRIENDS", 
        "MOI BAN BE" 
    };

    //IN PAGE GAME PLAY
    public static List<string> playBonus = new List<string>() 
    { 
        "BONUS", 
        "БОНУС", 
        "BONUS", 
        "BONUS",
        "BONUS",
        "BÔNUS", 
        "مكافاءة",
        "ボーナス",
        "보너스",
        "奖金",
        "CON ĐƯỜNG" 
    };
    public static List<string> playRoad = new List<string>() 
    { 
        "ROAD", 
        "ДОРОГА",
        "ROUTE",
        "STRASSE",
        "CAMINO",
        "ESTRADA",
        "الطريق",
        "道路", 
        "도로",
        "道路",
        "PHẦN THƯỞNG" 
    };
    public static List<string> playWinTop = new List<string>() 
    { 
        "YOU", 
        "ВЫ", 
        "TOI", 
        "DU HAST",
        "TÚ",
        "VOCÊ", 
        "أنت",
        "あなたは",
        "당신",
        "您", 
        "CHIẾN" 
    };
    public static List<string> playLoseTop = new List<string>() 
    { 
        "YOU", 
        "ТЫ", 
        "TOI", 
        "DU HAST",
        "TÚ",
        "VOCÊ", 
        "أنت",
        "あなたは",
        "당신",
        "您",
        "THẤT" 
    };
    public static List<string> playWinDown = new List<string>() 
    { 
        "WIN", 
        "ВЫИГРАЛ",
        "GAGNER",
        "GEWONNEN",
        "GANAR",
        "GANHOU",
        "فوز",
        "勝ちます", 
        "승리",
        "赢",
        "THẮNG" 
    };
    public static List<string> playLoseDown = new List<string>() 
    { 
        "LOSE", 
        "ПРОИГРАЛ",
        "PERDRE",
        "VERLOREN",
        "PERDER",
        "PERDEU",
        "خسارة",
        "負けます", 
        "잃다",
        "输",
        "BẠI" 
    };
    public static List<string> playYouWin = new List<string>() 
    { 
        "YOU WIN", 
        "ПОБЕДА",
        "GAGNÉ",
        "DU HAST GEWONNEN",
        "TÚ GANAS",
        "VOCÊ GANHOU",
        "أنت فزت",
        "あなたは 勝ちます", 
        "네가 이겼다",
        "你赢了",
        "CHIẾN THẮNG" 
    };
    public static List<string> playYouLose = new List<string>() 
    { 
        "YOU LOSE", 
        "ПОРАЖЕНИЕ",
        "PERDU",
        "DU HAST VERLOREN",
        "TÚ PIERDES",
        "VOCÊ PERDEU",
        "أنت خسرت",
        "あなたは 負けます", 
        "너 잃어",
        "你输了",
        "THẤT BẠI" 
    };
    public static List<string> playCoins = new List<string>() 
    { 
        "diamonds", 
        "бриллианты",
        "pièces",
        "münzen",
        "diamantes",
        "diamantes",
        "الماس",
        "ダイアモンド", 
        "동전",
        "钻石",
        "kim cương" 
    };
    public static List<string> playWinXTimes = new List<string>() 
    { 
        "WIN ? TIMES", 
        "ВЫИГРАТЬ ? РАЗА",
        "GAGNER ? FOIS",
        "GEWINNE ? MAL",
        "GANA ? VECES",
        "GANHE ? VEZES",
        "الفوز ?مرات",
        "? 回勝つ", 
        "? 번 우승",
        "赢 ? 次数", 
        "THẮNG ? LẦN" 
    };
    public static List<string> playBonusTitle = new List<string>() 
    { 
        "BONUS", 
        "БОНУС",
        "BONUS", 
        "BONUS", 
        "BONUS",
        "BÔNUS", 
        "مكافاءة", 
        "ボーナス", 
        "보너스", 
        "奖金", 
        "THƯỞNG" 
    };
    public static List<string> playBonusButton = new List<string>() 
    { 
        "OKAY", 
        "ЛАДНО", 
        "OK", 
        "OKAY", 
        "OKAY", 
        "OKAY",
        "حسنا", 
        "OK", 
        "괜찮아", 
        "好的",
        "ĐƯỢC" 
    };
    public static List<string> playBonusContent = new List<string>() 
    {
        "You get <color=orange>5000</color> diamonds and unlock the <color=green>Hunny Bunny</color> for the first time play.",
        "Вы получаете <color=orange>5000</color> БРИЛЛИАНТОВ и разблокируете <color=green>Hunny Bunny</color> в первый раз.",
        "Tuobtiens <color=orange>5000</color> pièces et débloques l'<color=green>Hunny Bunny</color> pour la première fois.",
        "Sie erhalten <color=orange>5000</color> Münzen und schalten <color=green>Hunny Bunny</color> frei, wenn Sie zum ersten Mal spielen.",
        "Usted consigue <color=orange>5000</color> diamantes y desbloquea el <color=green>Hunny Bunny</color> para jugar por 1ª vez.",
        "Você ganha <color=orange>5000</color> diamantes e desbloqueia o <color=green>Hunny Bunny</color> pela primeira vez.",
        "يمكنك الحصول على <color=orange>5000</color>النقود وفتح <color=green>Hunny Bunny</color>لأول مرة اللعب.",
        "あなたは <color=orange>5000</color> ダイアモンドを ゲットし、 最初の プレイのために <color=green>ハニーバニー</color> の ロックを 解除します。",
        "<color=orange>5000</color> 동전을 얻고 <color=green>Hunny Bunny</color> 를 처음으로 연다.",
        "你会获得 <color=orange>5000</color> 个钻石， 并解锁 <color=green>Hunny Bunny</color> 的第一次 游玩机会。",
        "Bạn nhận được <color=orange>5000</color> đồng tiền và mở khóa <color=green>Hunny Bunny</color> cho lần chơi đầu tiên."
    };
    public static List<string> playHighScore = new List<string>() 
    { 
        "HIGH SCORE", 
        "ВЫСОКИЙ БАЛ",
        "SCORE ÉLEVÉ",
        "HIGH SCORE", 
        "PUNTUACIÓN ALTA", 
        "ALTA PONTUAÇÃO",
        "أعلي النقاط", 
        "高得点", 
        "높은 점수", 
        "高分", 
        "ĐIỂM KỶ LỤC" 
    };

    //IN GUIDE
#if (UNITY_IOS || UNITY_ANDROID)
    public static List<string> playSwipeLeft = new List<string>() 
    { 
        "Swipe left", 
        "Проведи в лево", 
        "Glisser à gauche", 
        "Nach links wischen", 
        "Deslizar izquierda",
        "Deslizar paraesquerda",
        "اسحب يسار", 
        "左へ スワイプ", 
        "슬쩍 왼쪽",
        "向左滑动", 
        "Vuốt trái" 
    };
    public static List<string> playSwipeRight = new List<string>() 
    { 
        "Swipe right", 
        "Проведи в право", 
        "Glisser à droite",
        "Nach rechts wischen",
        "Deslizar derecha",
        "Deslizar para direita",
        "اسحب يمين", 
        "右へ スワイプ", 
        "슬쩍 오른쪽",
        "向右滑动", 
        "Vuốt phải" 
    };
    public static List<string> playSwipeUp = new List<string>() 
    { 
        "Swipe up", 
        "Проведи вверх", 
        "Glisser vers le haut", 
        "Nacho ben wischen",
        "Deslizar arriba",
        "Deslizar para cima",
        "اسحب للاعلى", 
        "上に スワイプ",
        "슬쩍 위",
        "向上滑动", 
        "Vuốt lên" 
    };
    public static List<string> playSwipeDown = new List<string>() 
    { 
        "Swipe down", 
        "Проведи вниз", 
        "Glisser vers le bas",
        "Nach unten wischen",
        "Deslizar abajo",
        "Deslizar para baixo",
        "اسحب أسفل", 
        "下に スワイプ",
        "슬쩍 아래",
        "向下滑动",
        "Vuốt xuống" 
    };
    public static List<string> playUseHoverboard = new List<string>() 
    { 
        "Double tap to\nuse <color=lime>HOVERBOARD</color>", 
        "Нажми дважды, чтобы\nиспользовать <color=lime>ДОСКУ</color>", 
        "Appuie deux fois pour\nutiliser l’<color=lime>HOVERBOARD</color>", 
        "Tippen Sie zweimal\num das <color=lime>HOVERBOARD</color> zu verwenden", 
        "Doble toque para\nusar <color=lime>HOVERBOARD</color>", 
        "Toque duas vezes para\nusar <color=lime>HOVERBOARD</color>", 
        "انقر نقرا مزدوجا\nلاستخدام <color=lime>HOVERBOARD</color>",
        "ダブルタップして\n<color=lime>ホバーボード</color> を使用する", 
        "<color=lime>HOVERBOARD</color> 를 사용하려면\n두 번 탭하세요.", 
        "双击使用\n<color=lime>悬浮滑板</color>。", 
        "Ấn đúp để\nsử dụng <color=lime>VÁN BAY</color>" 
    };
#else
    public static List<string> playSwipeLeft = new List<string>() 
    { 
        "Press left arrow", 
        "Нажмите стрелку влево", 
        "Appuyez flèche gauche", 
        "Drücken linker Pfeil", 
        "Prensa izquierda",
        "Pressione paraesquerda",
        "اضغط على اليسار", 
        "左矢印を 押す", 
        "왼쪽 화살표 누르기",
        "按左箭头", 
        "Ấn mũi tên trái" 
    };
    public static List<string> playSwipeRight = new List<string>() 
    { 
        "Press right arrow", 
        "Нажмите стрелку вправо", 
        "Appuyez flèche droite",
        "Drücken rechter Pfeil",
        "Prensa derecha",
        "Pressione para direita",
        "اضغط على اليمين", 
        "右矢印を 押す", 
        "를 눌러 오른쪽 화살표",
        "按右箭头", 
        "Ấn mũi tên phải" 
    };
    public static List<string> playSwipeUp = new List<string>() 
    { 
        "Press up arrow", 
        "Нажмите стрелку вверх", 
        "Appuyez flèche haut", 
        "Drücken oben Pfeil",
        "Prensa arriba",
        "Pressione para cima",
        "اضغط لأعلى", 
        "上矢印を 押す",
        "위쪽 화살표 누르기",
        "按向上箭头", 
        "Ấn mũi tên trên" 
    };
    public static List<string> playSwipeDown = new List<string>() 
    { 
        "Press down arrow", 
        "Нажмите стрелку вниз", 
        "Appuyez flèche bas",
        "Drücken runter Pfeil",
        "Prensa abajo",
        "Pressione para baixo",
        "اضغط لأسفل", 
        "下矢印を 押す",
        "아래쪽 화살표 누르기",
        "按下箭头",
        "Ấn mũi tên dưới" 
    };
    //Press SPACE to use HOVERBOARD
    public static List<string> playUseHoverboard = new List<string>() 
    { 
        "Press SPACE to\nuse <color=lime>HOVERBOARD</color>", 
        "Нажмите SPACE,\nчтобы использовать <color=lime>ДОСКУ</color>", 
        "Appuyez sur ESPACE\npour utiliser <color=lime>HOVERBOARD</color>", 
        "Drücken Sie SPACE\nverwenden <color=lime>HOVERBOARD</color>", 
        "Presione SPACE para\nusar <color=lime>HOVERBOARD</color>", 
        "Pressione SPACE para\nusar <color=lime>HOVERBOARD</color>", 
        "اضغط على سباس إلى\nلاستخدام <color=lime>HOVERBOARD</color>",
        "<color=lime>HOVERBOARD</color>を使用する\nには Space キーを 押します", 
        "<color=lime>HOVERBOARD</color> 를사용하려면\nSPACE를 누릅니다.", 
        "按空格键使用\n<color=lime>悬浮滑板</color>", 
        "Ấn phím CÁCH để\nsử dụng <color=lime>VÁN BAY</color>" 
    };
#endif
    public static List<string> playCatchFlyCam = new List<string>() 
    { 
        "Catch the Drone!", 
        "Поймай дрона!", 
        "Catch the Drone!", 
        "Catch the Drone!", 
        "Catch the Drone!", 
        "Catch the Drone!", 
        "Catch the Drone!",
        "Catch the Drone!", 
        "Catch the Drone!", 
        "Catch the Drone!", 
        "Bắt lấy Drone!" 
    };
    public static List<string> playDownBoat = new List<string>() 
    { 
        "Swipe down to increase speed", 
        "Swipe down to increase speed", 
        "Swipe down to increase speed", 
        "Swipe down to increase speed", 
        "Swipe down to increase speed", 
        "Swipe down to increase speed", 
        "Swipe down to increase speed",
        "Swipe down to increase speed", 
        "Swipe down to increase speed", 
        "Swipe down to increase speed", 
        "Vuốt xuống để tăng tốc độ" 
    };
    public static List<string> playUseHoverbike = new List<string>() 
    { 
        "To use <color=lime>HOVERBIKE</color>\nTap the button with the icon", 
        "Чтобы использовать <color=lime>ЛЕТОЦИКЛ</color>\nНажми кнопку со значком", 
        "Pour utiliser l’<color=lime>HOVERBIKE</color>\nAppuie sur le bouton avec l'icône", 
        "Um das <color=lime>HOVERBIKE</color> zu benutzen,\ntippen Sie auf die Schaltfläsche mit dem Symbol", 
        "Para usar <color=lime>HOVERBIKE</color>\nToque el botón del icono", 
        "Para usar <color=lime>HOVERBIKE</color>\nToque no botão com o ícone", 
        "لاستخدام <color=lime>HOVERBIKE</color>\nاضغط على زر مع الأيقون", 
        "<color=lime>ホバーボード</color> を 使用するには\nアイコンボタンを タップします。", 
        "<color=lime>HOVERBIKE</color> 를 사용하려면\n아이콘이있는 버튼을 누릅니다.", 
        "使用 <color=lime>悬浮滑板</color>\n用图标点 击按钮", 
        "Để sử dụng <color=lime>XE MÁY BAY</color>\nẤn nút có biểu tượng sau"
    };
    public static List<string> playBeginMove = new List<string>() 
    { 
        "Gorgeous moves!\n<color=lime>Let's GO!</color>", 
        "Классные движения!\n<color=lime>Погнали!</color>", 
        "Jolis coups!\n<color=lime>En avant!</color>",
        "Tolle Moves!\n<color=lime>LOS gehts!</color>", 
        "¡Qué movimientos!\n<color=lime>¡VAMOS!</color>", 
        "Belas manobras!\n<color=lime>Vamos lá!</color>", 
        "Gorgeous moves!\n<color=lime>Let's GO!</color>", 
        "素晴らしい 動きです！\n<color=lime>Let's GO!</color>",  
        "Gorgeous moves!\n<color=lime>Let's GO!</color>", 
        "Gorgeous moves!\n<color=lime>Let's GO!</color>", 
        "Cuộc hành trình\n<color=lime>Bắt đầu!</color>"
    };

    //OTHER MESSAGES
    public static List<string> playSaveMe = new List<string>() 
    { 
        "Save me!", 
        "Спаси меня!",
        "Sauve-moi!", 
        "Rette mich!",
        "¡Sálvame!",
        "Salve-me!",
        "انقذني!", 
        "私を 救って！",
        "구해줘!", 
        "救我！", 
        "Cứu tôi!" 
    };
    public static List<string> playSaveMeAds = new List<string>()
    {
        "Save me by watching ads",
        "Продолжить, за просмотр 1 видео",
        "Sauve-moi en regardant des annonces",
        "Rette mich indem du Werbung anschaust",
        "Sálvame viendo anuncios",
        "Salve-me assistindo anúncios",
        "انقذنيعن طريق مشاهدة الإعلانات",
        "広告を 見て 私を 救ってください",
        "광고를보고 나를 구해줘.",
        "通过观 看广告 来救我",
        "Xem quảng cáo để cứu tôi!"
    };
    public static List<string> playSetting = new List<string>() 
    { 
        "SETTINGS", 
        "НАСТРОЙКИ", 
        "RÉGLAGES", 
        "SETTINGS",
        "AJUSTES",
        "SETTINGS", 
        "إعدادات", 
        "設定",
        "놓음", 
        "设置", 
        "CÀI ĐẶT" 
    };
    public static List<string> playGoHome = new List<string>() 
    { 
        "HOME", 
        "ГЛАВНАЯ",
        "ACCUEIL",
        "ZUHAUSE",
        "IR CASA",
        "CASA", 
        "للمنزل", 
        "ホーム",
        "집에가",
        "回家", 
        "QUAY VỀ" 
    };
    public static List<string> playStartIn = new List<string>() 
    { 
        "Resume in", 
        "Продолжить через", 
        "Commence dans", 
        "Fortfahren in",
        "Empezar en",
        "Retomar em", 
        "الأستمرار خلال", 
        "再開する",
        "에서 시작", 
        "纳入简历", 
        "Tiếp tục trong" 
    };
    public static List<string> playKeyNeed = new List<string>() 
    { 
        "NEED KEYS:", 
        "НУЖНЫ КЛЮЧИ:",
        "BESOIN EN CLÉS:",
        "SCHLÜSSEL:", 
        "NECESITAR:", 
        "NECESSIDADE:",
        "تحتاج مفاتيح:", 
        "キーが必要です：",
        "요하다:",
        "需要钥匙：",
        "CHÌA KHÓA CẦN:" 
    };
    public static List<string> playMissionComplete = new List<string>() 
    { 
        "MISSION COMPLETE", 
        "MISSION COMPLETE",
        "MISSION COMPLETE",
        "MISSION COMPLETE", 
        "MISSION COMPLETE", 
        "MISSION COMPLETE",
        "MISSION COMPLETE", 
        "MISSION COMPLETE",
        "MISSION COMPLETE",
        "MISSION COMPLETE",
        "MISSION COMPLETE" 
    };
    public static List<string> playChallengeComplete = new List<string>() 
    { 
        "CHALLENGE COMPLETE", 
        "CHALLENGE COMPLETE",
        "CHALLENGE COMPLETE",
        "CHALLENGE COMPLETE", 
        "CHALLENGE COMPLETE", 
        "CHALLENGE COMPLETE",
        "CHALLENGE COMPLETE", 
        "CHALLENGE COMPLETE",
        "CHALLENGE COMPLETE",
        "CHALLENGE COMPLETE",
        "CHALLENGE COMPLETE" 
    };
    public static List<string> playDeliveryComplete = new List<string>()
    {
        "DELIVERY COMPLETE",
        "DELIVERY COMPLETE",
        "DELIVERY COMPLETE",
        "DELIVERY COMPLETE",
        "DELIVERY COMPLETE",
        "DELIVERY COMPLETE",
        "DELIVERY COMPLETE",
        "DELIVERY COMPLETE",
        "DELIVERY COMPLETE",
        "DELIVERY COMPLETE",
        "DELIVERY COMPLETE"
    };

    //IN PAGE HERO/HOVERBOARD
    public static List<string> heroCharacters = new List<string>() 
    { 
        "HERO", 
        "ГЕРОЙ",
        "HÉROS",
        "HELD",
        "HÉROE",
        "HERÓI", 
        "بطل",
        "ヒーロー", 
        "영웅",
        "英雄",
        "TÔI" 
    };
    public static List<string> heroHoverboard = new List<string>() 
    { 
        "BOARDS", 
        "ДОСКА",
        "BOARDS",
        "BOARDS",
        "BOARDS",
        "BOARDS",
        "BOARDS",
        "BOARDS",
        "BOARDS",
        "BOARDS",
        "VÁN BAY" 
    };
    public static List<string> heroJetpack = new List<string>() 
    { 
        "JETPACK", 
        "JETPACK", 
        "JETPACK", 
        "JETPACK", 
        "JETPACK", 
        "JETPACK", 
        "JETPACK", 
        "JETPACK", 
        "JETPACK", 
        "喷射背包",
        "JETPACK"
    };
    public static List<string> heroBoat = new List<string>() 
    { 
        "BOATS", 
        "ЛОДКИ", 
        "BOATS", 
        "BOATS", 
        "BOATS", 
        "BOATS", 
        "BOATS", 
        "BOATS", 
        "BOATS", 
        "BOATS",
        "THUYỀN"
    };
    public static List<string> heroNotEnough = new List<string>() 
    { 
        "NOT ENOUGH", 
        "НЕ ДОСТАТОЧНО",
        "PAS ASSEZ",
        "NICHT GENUG",
        "NO SUFICIENTE",
        "NÃO SUFICIENTE", 
        "لا يكفي", 
        "十分ではありません",
        "충분하지 않은",
        "不够",
        "KHÔNG ĐỦ" 
    };
    public static List<string> heroSelected = new List<string>() 
    { 
        "SELECTED", 
        "ВЫБРАНО", 
        "SÉLECTIONNÉ", 
        "AUSGEWÄHLT",
        "SELECCIONADO", 
        "SELECIONADO", 
        "مختارة",
        "選択された",
        "선택된",
        "选择",
        "ĐÃ CHỌN" 
    };
    public static List<string> heroUnlocked = new List<string>() 
    { 
        "UNLOCKED", 
        "РАЗБЛОКИРОВАНО", 
        "DÉBLOQUÉ",
        "FREIGESCHALTET",
        "DESBLOQUEADO",
        "DESBOQUEADO", 
        "مفتوحة",
        "解除された",
        "잠금 해제 됨", 
        "解锁", 
        "ĐÃ MUA" 
    };
    public static List<string> heroTrial = new List<string>() 
    { 
        "TRY", 
        "ПРОБУЙ", 
        "ESSAYER", 
        "TRY", 
        "PROBAR", 
        "TESTE", 
        "جرب", 
        "試す", 
        "시험", 
        "试",
        "THỬ"
    };
    public static List<List<string>> heroInfoHero = new List<List<string>>() { 
        new List<string>()
        {
            "Name: Blaze\nMale\nBriton\n16 years old\nHeight: 175 cm\nWeight: 56 kg\nHobbies: Footbal",
            "Имя: Blaze\nМужской\nBriton\n16 лет\nРост: 175 cm\nВес: 56 kg\nУвлечения: Footbal",
            "Nom: Blaze\nHomme\nBriton\n16 ans\nTaille: 175 cm\nPoids: 56 kg\nLoisirs: Footbal",
            "Name: Blaze\nMännlich\nBriton\n16 Jahre alt\nGröße: 175 cm\nGewicht: 56 kg\nHobby: Footbal",
            "Nombre: Blaze\nHombre\nBriton\n16 años\nAltura: 175 cm\nPeso: 56 kg\nPasatiempos: Footbal",
            "Nome: Blaze\nMale\nBriton\n16 years\nAltura: 175 cm\nPeso: 56 kg\nPassatempos: Footbal",
            "الاسم: Blaze\nذكر \nBriton\n16 سنة \nالطول: 175 سم \nالوزن: 56 كجم \nالهوايات: Footbal",
            "名前：Blaze\n男性\nBriton\n16 歳\n身長：175 cm\n体重：56 kg\n趣味： Footbal",
            "이름 : Blaze\n남성\nBriton\n16 세\n높이 : 175 cm\n무게 : 56 kg\n취미 : Footbal",
            "姓名：Blaze\n男\nBriton\n16岁\n身高：175 厘米\n体重：56 公斤\n爱好： Footbal",
            "Tên: Blaze\nNam giới\nBriton\n16 tuổi\nCao: 175 cm\nNặng: 56 kg\nSở thích: Footbal"
        },
        new List<string>()
        {
            "Name: Sophia\nFemale\nBrazilian\n16 years old\nHeight: 152 cm\nWeight: 45 kg\nHobbies: Surfing",
            "Имя: Sophia\nЖенщина\nBrazilian\n16 лет\nРост: 152 cm\nВес: 45 kg\nУвлечения: Surfing",
            "Nom: Sophia\nFemme\nBrazilian\n16 ans\nTaille: 152 cm\nPoids: 45 kg\nLoisirs: Surfing",
            "Name: Sophia\nWeiblich\nBrazilian\n16 Jahre alt\nGröße: 152 cm\nGewicht: 45 kg\nHobby: Surfing",
            "Nombre: Sophia\nHembra\nBrazilian\n16 años\nAltura: 152 cm\nPeso: 45 kg\nPasatiempos: Surfing",
            "Nome: Sophia\nFeminino\nBrazilian\n16 anos\nAltura: 152 cm\nPeso: 45 kg\nPassatempos: Surfing",
            "الاسم: Sophia\nأنثى \nBrazilian\n16 سنة \nالطول: 152 سم \nالوزن: 45 كجم \nالهوايات: Surfing",
            "名前：Sophia\n女性\nBrazilian\n16 歳\n身長：152 cm\n体重：45 kg\n趣味： Surfing",
            "이름 : Sophia\n여성\nBrazilian\n16 세\n높이 : 152 cm\n무게 : 45 kg\n취미 : Surfing",
            "姓名：Sophia\n女性\nBrazilian\n16岁\n身高：152 厘米\n体重：45 公斤\n爱好： Surfing",
            "Tên: Sophia\nNữ giới\nBrazilian\n16 tuổi\nCao: 152 cm\nNặng: 45 kg\nSở thích: Surfing"
        },
        new List<string>()
        {
            "Name: Biggy\nMale\nAustralian\n15 years old\nHeight: 168 cm\nWeight: 80 kg\nHobbies: Hip Hop",
            "Имя: Biggy\nМужской\nAustralian\n15 лет\nРост: 168 cm\nВес: 80 kg\nУвлечения: Hip Hop",
            "Nom: Biggy\nHomme\nAustralian\n15 ans\nTaille: 168 cm\nPoids: 80 kg\nLoisirs: Hip Hop",
            "Name: Biggy\nMännlich\nAustralian\n15 Jahre alt\nGröße: 168 cm\nGewicht: 80 kg\nHobby: Hip Hop",
            "Nombre: Biggy\nHombre\nAustralian\n15 años\nAltura: 168 cm\nPeso: 80 kg\nPasatiempos: Hip Hop",
            "Nome: Biggy\nMale\nAustralian\n15 years\nAltura: 168 cm\nPeso: 80 kg\nPassatempos: Hip Hop",
            "الاسم: Biggy\nذكر \nAustralian\n15 سنة \nالطول: 168 سم \nالوزن: 80 كجم \nالهوايات: Hip Hop",
            "名前：Biggy\n男性\nAustralian\n15 歳\n身長：168 cm\n体重：80 kg\n趣味： Hip Hop",
            "이름 : Biggy\n남성\nAustralian\n15 세\n높이 : 168 cm\n무게 : 80 kg\n취미 : Hip Hop",
            "姓名：Biggy\n男\nAustralian\n15岁\n身高：168 厘米\n体重：80 公斤\n爱好： Hip Hop",
            "Tên: Biggy\nNam giới\nAustralian\n15 tuổi\nCao: 168 cm\nNặng: 80 kg\nSở thích: Hip Hop"
        },
        new List<string>()
        {
            "Name: Ava\nFemale\nTexas\n16 years old\nHeight: 178 cm\nWeight: 45 kg\nHobbies: Country music",
            "Имя: Ava\nЖенщина\nTexas\n16 лет\nРост: 178 cm\nВес: 45 kg\nУвлечения: Country music",
            "Nom: Ava\nFemme\nTexas\n16 ans\nTaille: 178 cm\nPoids: 45 kg\nLoisirs: Country music",
            "Name: Ava\nWeiblich\nTexas\n16 Jahre alt\nGröße: 178 cm\nGewicht: 45 kg\nHobby: Country music",
            "Nombre: Ava\nHembra\nTexas\n16 años\nAltura: 178 cm\nPeso: 45 kg\nPasatiempos: Country music",
            "Nome: Ava\nFeminino\nTexas\n16 anos\nAltura: 178 cm\nPeso: 45 kg\nPassatempos: Country music",
            "الاسم: Ava\nأنثى \nTexas\n16 سنة \nالطول: 178 سم \nالوزن: 45 كجم \nالهوايات: Country music",
            "名前：Ava\n女性\nTexas\n16 歳\n身長：178 cm\n体重：45 kg\n趣味： Country music",
            "이름 : Ava\n여성\nTexas\n16 세\n높이 : 178 cm\n무게 : 45 kg\n취미 : Country music",
            "姓名：Ava\n女性\nTexas\n16岁\n身高：178 厘米\n体重：45 公斤\n爱好： Country music",
            "Tên: Ava\nNữ giới\nTexas\n16 tuổi\nCao: 178 cm\nNặng: 45 kg\nSở thích: Country music"
        },
        new List<string>()
        {
            "Name: Marty\nMale\nMartian\nUnknown years old\nHeight: 180 cm\nWeight: 28 kg\nHobbies: Space Travel",
            "Имя: Marty\nМужской\nMartian\nUnknown лет\nРост: 180 cm\nВес: 28 kg\nУвлечения: Space Travel",
            "Nom: Marty\nHomme\nMartian\nUnknown ans\nTaille: 180 cm\nPoids: 28 kg\nLoisirs: Space Travel",
            "Name: Marty\nMännlich\nMartian\nUnknown Jahre alt\nGröße: 180 cm\nGewicht: 28 kg\nHobby: Space Travel",
            "Nombre: Marty\nHombre\nMartian\nUnknown años\nAltura: 180 cm\nPeso: 28 kg\nPasatiempos: Space Travel",
            "Nome: Marty\nMale\nMartian\nUnknown years\nAltura: 180 cm\nPeso: 28 kg\nPassatempos: Space Travel",
            "الاسم: Marty\nذكر \nMartian\nUnknown سنة \nالطول: 180 سم \nالوزن: 28 كجم \nالهوايات: Space Travel",
            "名前：Marty\n男性\nMartian\nUnknown 歳\n身長：180 cm\n体重：28 kg\n趣味： Space Travel",
            "이름 : Marty\n남성\nMartian\nUnknown 세\n높이 : 180 cm\n무게 : 28 kg\n취미 : Space Travel",
            "姓名：Marty\n男\nMartian\nUnknown岁\n身高：180 厘米\n体重：28 公斤\n爱好： Space Travel",
            "Tên: Marty\nNam giới\nMartian\nUnknown tuổi\nCao: 180 cm\nNặng: 28 kg\nSở thích: Space Travel"
        },
        new List<string>()
        {
            "Name: Balthy\nMale\nAustralian\n17 years old\nHeight: 178 cm\nWeight: 58 kg\nHobbies: Magic tricks",
            "Имя: Balthy\nМужской\nAustralian\n17 лет\nРост: 178 cm\nВес: 58 kg\nУвлечения: Magic tricks",
            "Nom: Balthy\nHomme\nAustralian\n17 ans\nTaille: 178 cm\nPoids: 58 kg\nLoisirs: Magic tricks",
            "Name: Balthy\nMännlich\nAustralian\n17 Jahre alt\nGröße: 178 cm\nGewicht: 58 kg\nHobby: Magic tricks",
            "Nombre: Balthy\nHombre\nAustralian\n17 años\nAltura: 178 cm\nPeso: 58 kg\nPasatiempos: Magic tricks",
            "Nome: Balthy\nMale\nAustralian\n17 years\nAltura: 178 cm\nPeso: 58 kg\nPassatempos: Magic tricks",
            "الاسم: Balthy\nذكر \nAustralian\n17 سنة \nالطول: 178 سم \nالوزن: 58 كجم \nالهوايات: Magic tricks",
            "名前：Balthy\n男性\nAustralian\n17 歳\n身長：178 cm\n体重：58 kg\n趣味： Magic tricks",
            "이름 : Balthy\n남성\nAustralian\n17 세\n높이 : 178 cm\n무게 : 58 kg\n취미 : Magic tricks",
            "姓名：Balthy\n男\nAustralian\n17岁\n身高：178 厘米\n体重：58 公斤\n爱好： Magic tricks",
            "Tên: Balthy\nNam giới\nAustralian\n17 tuổi\nCao: 178 cm\nNặng: 58 kg\nSở thích: Magic tricks"
        },
        new List<string>()
        {
            "Name: Glinda\nFemale\nUnknown\nUnknown years old\nHeight: 160 cm\nWeight: 40 kg\nHobbies: Potion recipes",
            "Имя: Glinda\nЖенщина\nUnknown\nUnknown лет\nРост: 160 cm\nВес: 40 kg\nУвлечения: Potion recipes",
            "Nom: Glinda\nFemme\nUnknown\nUnknown ans\nTaille: 160 cm\nPoids: 40 kg\nLoisirs: Potion recipes",
            "Name: Glinda\nWeiblich\nUnknown\nUnknown Jahre alt\nGröße: 160 cm\nGewicht: 40 kg\nHobby: Potion recipes",
            "Nombre: Glinda\nHembra\nUnknown\nUnknown años\nAltura: 160 cm\nPeso: 40 kg\nPasatiempos: Potion recipes",
            "Nome: Glinda\nFeminino\nUnknown\nUnknown anos\nAltura: 160 cm\nPeso: 40 kg\nPassatempos: Potion recipes",
            "الاسم: Glinda\nأنثى \nUnknown\nUnknown سنة \nالطول: 160 سم \nالوزن: 40 كجم \nالهوايات: Potion recipes",
            "名前：Glinda\n女性\nUnknown\nUnknown 歳\n身長：160 cm\n体重：40 kg\n趣味： Potion recipes",
            "이름 : Glinda\n여성\nUnknown\nUnknown 세\n높이 : 160 cm\n무게 : 40 kg\n취미 : Potion recipes",
            "姓名：Glinda\n女性\nUnknown\nUnknown岁\n身高：160 厘米\n体重：40 公斤\n爱好： Potion recipes",
            "Tên: Glinda\nNữ giới\nUnknown\nUnknown tuổi\nCao: 160 cm\nNặng: 40 kg\nSở thích: Potion recipes"
        }
    };
    public static List<List<string>> heroInfoHoverboard = new List<List<string>>() { 
        new List<string>() 
        {
            "Tourister 2000\nLength: 75 cm\nWidth: 24 cm\nWeight: 2.0 kg",
            "Tourister 2000\nДлина: 75 cm\nШирина: 24 cm\nВес: 2.0 kg",
            "Tourister 2000\nLongueur: 75 cm\nLargeur: 24 cm\nPoids: 2.0 kg",
            "Tourister 2000\nLänge: 75 cm\nBreite: 24 cm\nGewicht: 2.0 kg",
            "Tourister 2000\nLargo: 75 cm\nAncho: 24 cm\nPeso: 2.0 kg",
            "Tourister 2000\nComprimento: 75 cm\nLargura: 24 cm\nPeso: 2.0 kg",
            "Tourister 2000\nالطول: 75 سم \nالعرض: 24 سم \nالوزن: 2.0 كجم",
            "Tourister 2000\n長さ：75 cm\n幅：24 cm\n重量：2.0 kg",
            "Tourister 2000\n길이: 75 cm\n너비: 24 cm\n무게: 2.0 kg",
            "Tourister 2000\n长度：75 厘米\n宽度：24 厘米\n重量：2.0 公斤",
            "Tourister 2000\nDài: 75 cm\nRộng: 24 cm\nNặng: 2.0 kg"
        }, 
        new List<string>() 
        {
            "Outspace SL\nLength: 70 cm\nWidth: 22 cm\nWeight: 2.5 kg",
            "Outspace SL\nДлина: 70 cm\nШирина: 22 cm\nВес: 2.5 kg",
            "Outspace SL\nLongueur: 70 cm\nLargeur: 22 cm\nPoids: 2.5 kg",
            "Outspace SL\nLänge: 70 cm\nBreite: 22 cm\nGewicht: 2.5 kg",
            "Outspace SL\nLargo: 70 cm\nAncho: 22 cm\nPeso: 2.5 kg",
            "Outspace SL\nComprimento: 70 cm\nLargura: 22 cm\nPeso: 2.5 kg",
            "Outspace SL\nالطول: 70 سم \nالعرض: 22 سم \nالوزن: 2.5 كجم",
            "Outspace SL\n長さ：70 cm\n幅：22 cm\n重量：2.5 kg",
            "Outspace SL\n길이: 70 cm\n너비: 22 cm\n무게: 2.5 kg",
            "Outspace SL\n长度：70 厘米\n宽度：22 厘米\n重量：2.5 公斤",
            "Outspace SL\nDài: 70 cm\nRộng: 22 cm\nNặng: 2.5 kg"
        }, 
        new List<string>() 
        {
            "Splitex G Force\nLength: 65 cm\nWidth: 20 cm\nWeight: 1.5 kg",
            "Splitex G Force\nДлина: 65 cm\nШирина: 20 cm\nВес: 1.5 kg",
            "Splitex G Force\nLongueur: 65 cm\nLargeur: 20 cm\nPoids: 1.5 kg",
            "Splitex G Force\nLänge: 65 cm\nBreite: 20 cm\nGewicht: 1.5 kg",
            "Splitex G Force\nLargo: 65 cm\nAncho: 20 cm\nPeso: 1.5 kg",
            "Splitex G Force\nComprimento: 65 cm\nLargura: 20 cm\nPeso: 1.5 kg",
            "Splitex G Force\nالطول: 65 سم \nالعرض: 20 سم \nالوزن: 1.5 كجم",
            "Splitex G Force\n長さ：65 cm\n幅：20 cm\n重量：1.5 kg",
            "Splitex G Force\n길이: 65 cm\n너비: 20 cm\n무게: 1.5 kg",
            "Splitex G Force\n长度：65 厘米\n宽度：20 厘米\n重量：1.5 公斤",
            "Splitex G Force\nDài: 65 cm\nRộng: 20 cm\nNặng: 1.5 kg"
        }, 
        new List<string>() 
        {
            "Speedster\nLength: 80 cm\nWidth: 26 cm\nWeight: 2.2 kg",
            "Speedster\nДлина: 80 cm\nШирина: 26 cm\nВес: 2.2 kg",
            "Speedster\nLongueur: 80 cm\nLargeur: 26 cm\nPoids: 2.2 kg",
            "Speedster\nLänge: 80 cm\nBreite: 26 cm\nGewicht: 2.2 kg",
            "Speedster\nLargo: 80 cm\nAncho: 26 cm\nPeso: 2.2 kg",
            "Speedster\nComprimento: 80 cm\nLargura: 26 cm\nPeso: 2.2 kg",
            "Speedster\nالطول: 80 سم \nالعرض: 26 سم \nالوزن: 2.2 كجم",
            "Speedster\n長さ：80 cm\n幅：26 cm\n重量：2.2 kg",
            "Speedster\n길이: 80 cm\n너비: 26 cm\n무게: 2.2 kg",
            "Speedster\n长度：80 厘米\n宽度：26 厘米\n重量：2.2 公斤",
            "Speedster\nDài: 80 cm\nRộng: 26 cm\nNặng: 2.2 kg"
        }, 
        new List<string>() 
        {
            "Impedus Magnus\nLength: 82 cm\nWidth: 30 cm\nWeight: 2.5 kg",
            "Impedus Magnus\nДлина: 82 cm\nШирина: 30 cm\nВес: 2.5 kg",
            "Impedus Magnus\nLongueur: 82 cm\nLargeur: 30 cm\nPoids: 2.5 kg",
            "Impedus Magnus\nLänge: 82 cm\nBreite: 30 cm\nGewicht: 2.5 kg",
            "Impedus Magnus\nLargo: 82 cm\nAncho: 30 cm\nPeso: 2.5 kg",
            "Impedus Magnus\nComprimento: 82 cm\nLargura: 30 cm\nPeso: 2.5 kg",
            "Impedus Magnus\nالطول: 82 سم \nالعرض: 30 سم \nالوزن: 2.5 كجم",
            "Impedus Magnus\n長さ：82 cm\n幅：30 cm\n重量：2.5 kg",
            "Impedus Magnus\n길이: 82 cm\n너비: 30 cm\n무게: 2.5 kg",
            "Impedus Magnus\n长度：82 厘米\n宽度：30 厘米\n重量：2.5 公斤",
            "Impedus Magnus\nDài: 82 cm\nRộng: 30 cm\nNặng: 2.5 kg"
        },
        new List<string>() 
        {
            "Hunny Bunny\nLength: 78 cm\nWidth: 25 cm\nWeight: 1.8 kg",
            "Hunny Bunny\nДлина: 78 cm\nШирина: 25 cm\nВес: 1.8 kg",
            "Hunny Bunny\nLongueur: 78 cm\nLargeur: 25 cm\nPoids: 1.8 kg",
            "Hunny Bunny\nLänge: 78 cm\nBreite: 25 cm\nGewicht: 1.8 kg",
            "Hunny Bunny\nLargo: 78 cm\nAncho: 25 cm\nPeso: 1.8 kg",
            "Hunny Bunny\nComprimento: 78 cm\nLargura: 25 cm\nPeso: 1.8 kg",
            "Hunny Bunny\nالطول: 78 سم \nالعرض: 25 سم \nالوزن: 1.8 كجم",
            "Hunny Bunny\n長さ：78 cm\n幅：25 cm\n重量：1.8 kg",
            "Hunny Bunny\n길이: 78 cm\n너비: 25 cm\n무게: 1.8 kg",
            "Hunny Bunny\n长度：78 厘米\n宽度：25 厘米\n重量：1.8 公斤",
            "Hunny Bunny\nDài: 78 cm\nRộng: 25 cm\nNặng: 1.8 kg"
        },
        new List<string>() 
        {
            "Rock Guitar\nLength: 88 cm\nWidth: 23 cm\nWeight: 2.1 kg",
            "Rock Guitar\nДлина: 88 cm\nШирина: 23 cm\nВес: 2.1 kg",
            "Rock Guitar\nLongueur: 88 cm\nLargeur: 23 cm\nPoids: 2.1 kg",
            "Rock Guitar\nLänge: 88 cm\nBreite: 23 cm\nGewicht: 2.1 kg",
            "Rock Guitar\nLargo: 88 cm\nAncho: 23 cm\nPeso: 2.1 kg",
            "Rock Guitar\nComprimento: 88 cm\nLargura: 23 cm\nPeso: 2.1 kg",
            "Rock Guitar\nالطول: 88 سم \nالعرض: 23 سم \nالوزن: 2.1 كجم",
            "Rock Guitar\n長さ：88 cm\n幅：23 cm\n重量：2.1 kg",
            "Rock Guitar\n길이: 88 cm\n너비: 23 cm\n무게: 2.1 kg",
            "Rock Guitar\n长度：88 厘米\n宽度：23 厘米\n重量：2.1 公斤",
            "Rock Guitar\nDài: 88 cm\nRộng: 23 cm\nNặng: 2.1 kg"
        },
        new List<string>() 
        {
            "Phantom\nLength: 80 cm\nWidth: 28 cm\nWeight: 0.5 kg",
            "Phantom\nДлина: 80 cm\nШирина: 28 cm\nВес: 0.5 kg",
            "Phantom\nLongueur: 80 cm\nLargeur: 28 cm\nPoids: 0.5 kg",
            "Phantom\nLänge: 80 cm\nBreite: 28 cm\nGewicht: 0.5 kg",
            "Phantom\nLargo: 80 cm\nAncho: 28 cm\nPeso: 0.5 kg",
            "Phantom\nComprimento: 80 cm\nLargura: 28 cm\nPeso: 0.5 kg",
            "Phantom\nالطول: 80 سم \nالعرض: 28 سم \nالوزن: 0.5 كجم",
            "Phantom\n長さ：80 cm\n幅：28 cm\n重量：0.5 kg",
            "Phantom\n길이: 80 cm\n너비: 28 cm\n무게: 0.5 kg",
            "Phantom\n长度：80 厘米\n宽度：28 厘米\n重量：0.5 公斤",
            "Phantom\nDài: 80 cm\nRộng: 28 cm\nNặng: 0.5 kg"
        },
        new List<string>() 
        {
            "Kareta\nLength: 75 cm\nWidth: 40 cm\nWeight: 3.5 kg",
            "Kareta\nДлина: 75 cm\nШирина: 40 cm\nВес: 3.5 kg",
            "Kareta\nLongueur: 75 cm\nLargeur: 40 cm\nPoids: 3.5 kg",
            "Kareta\nLänge: 75 cm\nBreite: 40 cm\nGewicht: 3.5 kg",
            "Kareta\nLargo: 75 cm\nAncho: 40 cm\nPeso: 3.5 kg",
            "Kareta\nComprimento: 75 cm\nLargura: 40 cm\nPeso: 3.5 kg",
            "Kareta\nالطول: 75 سم \nالعرض: 40 سم \nالوزن: 3.5 كجم",
            "Kareta\n長さ：75 cm\n幅：40 cm\n重量：3.5 kg",
            "Kareta\n길이: 75 cm\n너비: 40 cm\n무게: 3.5 kg",
            "Kareta\n长度：75 厘米\n宽度：40 厘米\n重量：3.5 公斤",
            "Kareta\nDài: 75 cm\nRộng: 40 cm\nNặng: 3.5 kg"
        },
        new List<string>() 
        {
            "Turbo GX Sport\nLength: 80 cm\nWidth: 50 cm\nWeight: 3.8 kg",
            "Turbo GX Sport\nДлина: 80 cm\nШирина: 50 cm\nВес: 3.8 kg",
            "Turbo GX Sport\nLongueur: 80 cm\nLargeur: 50 cm\nPoids: 3.8 kg",
            "Turbo GX Sport\nLänge: 80 cm\nBreite: 50 cm\nGewicht: 3.8 kg",
            "Turbo GX Sport\nLargo: 80 cm\nAncho: 50 cm\nPeso: 3.8 kg",
            "Turbo GX Sport\nComprimento: 80 cm\nLargura: 50 cm\nPeso: 3.8 kg",
            "Turbo GX Sport\nالطول: 80 سم \nالعرض: 50 سم \nالوزن: 3.8 كجم",
            "Turbo GX Sport\n長さ：80 cm\n幅：50 cm\n重量：3.8 kg",
            "Turbo GX Sport\n길이: 80 cm\n너비: 50 cm\n무게: 3.8 kg",
            "Turbo GX Sport\n长度：80 厘米\n宽度：50 厘米\n重量：3.8 公斤",
            "Turbo GX Sport\nDài: 80 cm\nRộng: 50 cm\nNặng: 3.8 kg"
        },
        new List<string>()
        {
            "Neo Copter\nLength: 118 cm\nWidth: 28 cm\nWeight: 2.4 kg",
            "Neo Copter\nДлина: 118 cm\nШирина: 28 cm\nВес: 2.4 kg",
            "Neo Copter\nLongueur: 118 cm\nLargeur: 28 cm\nPoids: 2.4 kg",
            "Neo Copter\nLänge: 118 cm\nBreite: 28 cm\nGewicht: 2.4 kg",
            "Neo Copter\nLargo: 118 cm\nAncho: 28 cm\nPeso: 2.4 kg",
            "Neo Copter\nComprimento: 118 cm\nLargura: 28 cm\nPeso: 2.4 kg",
            "Neo Copter\nالطول: 118 سم \nالعرض: 28 سم \nالوزن: 2.4 كجم",
            "Neo Copter\n長さ：118 cm\n幅：28 cm\n重量：2.4 kg",
            "Neo Copter\n길이: 118 cm\n너비: 28 cm\n무게: 2.4 kg",
            "Neo Copter\n长度：118 厘米\n宽度：28 厘米\n重量：2.4 公斤",
            "Neo Copter\nDài: 118 cm\nRộng: 28 cm\nNặng: 2.4 kg"
        },
        new List<string>()
        {
            "Super Sonic GT\nLength: 135 cm\nWidth: 55 cm\nWeight: 3.8 kg",
            "Super Sonic GT\nДлина: 135 cm\nШирина: 55 cm\nВес: 3.8 kg",
            "Super Sonic GT\nLongueur: 135 cm\nLargeur: 55 cm\nPoids: 3.8 kg",
            "Super Sonic GT\nLänge: 135 cm\nBreite: 55 cm\nGewicht: 3.8 kg",
            "Super Sonic GT\nLargo: 135 cm\nAncho: 55 cm\nPeso: 3.8 kg",
            "Super Sonic GT\nComprimento: 135 cm\nLargura: 55 cm\nPeso: 3.8 kg",
            "Super Sonic GT\nالطول: 135 سم \nالعرض: 55 سم \nالوزن: 3.8 كجم",
            "Super Sonic GT\n長さ：135 cm\n幅：55 cm\n重量：3.8 kg",
            "Super Sonic GT\n길이: 135 cm\n너비: 55 cm\n무게: 3.8 kg",
            "Super Sonic GT\n长度：135 厘米\n宽度：55 厘米\n重量：3.8 公斤",
            "Super Sonic GT\nDài: 135 cm\nRộng: 55 cm\nNặng: 3.8 kg"
        },
        new List<string>()
        {
            "Tourister XT\nLength: 189 cm\nWidth: 90 cm\nWeight: 38 kg",
            "Tourister XT\nДлина: 189 cm\nШирина: 90 cm\nВес: 38 kg",
            "Tourister XT\nLongueur: 189 cm\nLargeur: 90 cm\nPoids: 38 kg",
            "Tourister XT\nLänge: 189 cm\nBreite: 90 cm\nGewicht: 38 kg",
            "Tourister XT\nLargo: 189 cm\nAncho: 90 cm\nPeso: 38 kg",
            "Tourister XT\nComprimento: 189 cm\nLargura: 90 cm\nPeso: 38 kg",
            "Tourister XT\nالطول: 189 سم \nالعرض: 90 سم \nالوزن: 38 كجم",
            "Tourister XT\n長さ：189 cm\n幅：90 cm\n重量：38 kg",
            "Tourister XT\n길이: 189 cm\n너비: 90 cm\n무게: 38 kg",
            "Tourister XT\n长度：189 厘米\n宽度：90 厘米\n重量：38 公斤",
            "Tourister XT\nDài: 189 cm\nRộng: 90 cm\nNặng: 38 kg"
        },
        new List<string>()
        {
            "Windrunner Sport\nLength: 205 cm\nWidth: 75 cm\nWeight: 28 kg",
            "Windrunner Sport\nДлина: 205 cm\nШирина: 75 cm\nВес: 28 kg",
            "Windrunner Sport\nLongueur: 205 cm\nLargeur: 75 cm\nPoids: 28 kg",
            "Windrunner Sport\nLänge: 205 cm\nBreite: 75 cm\nGewicht: 28 kg",
            "Windrunner Sport\nLargo: 205 cm\nAncho: 75 cm\nPeso: 28 kg",
            "Windrunner Sport\nComprimento: 205 cm\nLargura: 75 cm\nPeso: 28 kg",
            "Windrunner Sport\nالطول: 205 سم \nالعرض: 75 سم \nالوزن: 28 كجم",
            "Windrunner Sport\n長さ：205 cm\n幅：75 cm\n重量：28 kg",
            "Windrunner Sport\n길이: 205 cm\n너비: 75 cm\n무게: 28 kg",
            "Windrunner Sport\n长度：205 厘米\n宽度：75 厘米\n重量：28 公斤",
            "Windrunner Sport\nDài: 205 cm\nRộng: 75 cm\nNặng: 28 kg"
        },
        new List<string>()
        {
            "Rail Blazer GT\nLength: 220 cm\nWidth: 70 cm\nWeight: 24 kg",
            "Rail Blazer GT\nДлина: 220 cm\nШирина: 70 cm\nВес: 24 kg",
            "Rail Blazer GT\nLongueur: 220 cm\nLargeur: 70 cm\nPoids: 24 kg",
            "Rail Blazer GT\nLänge: 220 cm\nBreite: 70 cm\nGewicht: 24 kg",
            "Rail Blazer GT\nLargo: 220 cm\nAncho: 70 cm\nPeso: 24 kg",
            "Rail Blazer GT\nComprimento: 220 cm\nLargura: 70 cm\nPeso: 24 kg",
            "Rail Blazer GT\nالطول: 220 سم \nالعرض: 70 سم \nالوزن: 24 كجم",
            "Rail Blazer GT\n長さ：220 cm\n幅：70 cm\n重量：24 kg",
            "Rail Blazer GT\n길이: 220 cm\n너비: 70 cm\n무게: 24 kg",
            "Rail Blazer GT\n长度：220 厘米\n宽度：70 厘米\n重量：24 公斤",
            "Rail Blazer GT\nDài: 220 cm\nRộng: 70 cm\nNặng: 24 kg"
        },
        new List<string>()
        {
            "Velociter 9000GT\nLength: 228 cm\nWidth: 68 cm\nWeight: 18 kg",
            "Velociter 9000GT\nДлина: 228 cm\nШирина: 68 cm\nВес: 18 kg",
            "Velociter 9000GT\nLongueur: 228 cm\nLargeur: 68 cm\nPoids: 18 kg",
            "Velociter 9000GT\nLänge: 228 cm\nBreite: 68 cm\nGewicht: 18 kg",
            "Velociter 9000GT\nLargo: 228 cm\nAncho: 68 cm\nPeso: 18 kg",
            "Velociter 9000GT\nComprimento: 228 cm\nLargura: 68 cm\nPeso: 18 kg",
            "Velociter 9000GT\nالطول: 228 سم \nالعرض: 68 سم \nالوزن: 18 كجم",
            "Velociter 9000GT\n長さ：228 cm\n幅：68 cm\n重量：18 kg",
            "Velociter 9000GT\n길이: 228 cm\n너비: 68 cm\n무게: 18 kg",
            "Velociter 9000GT\n长度：228 厘米\n宽度：68 厘米\n重量：18 公斤",
            "Velociter 9000GT\nDài: 228 cm\nRộng: 68 cm\nNặng: 18 kg"
        },
        new List<string>()
        {
            "Martian Cruiser\nLength: 80 cm\nWidth: 80 cm\nWeight: 3 kg",
            "Martian Cruiser\nДлина: 80 cm\nШирина: 80 cm\nВес: 3 kg",
            "Martian Cruiser\nLongueur: 80 cm\nLargeur: 80 cm\nPoids: 3 kg",
            "Martian Cruiser\nLänge: 80 cm\nBreite: 80 cm\nGewicht: 3 kg",
            "Martian Cruiser\nLargo: 80 cm\nAncho: 80 cm\nPeso: 3 kg",
            "Martian Cruiser\nComprimento: 80 cm\nLargura: 80 cm\nPeso: 3 kg",
            "Martian Cruiser\nالطول: 80 سم \nالعرض: 80 سم \nالوزن: 3 كجم",
            "Martian Cruiser\n長さ：80 cm\n幅：80 cm\n重量：3 kg",
            "Martian Cruiser\n길이: 80 cm\n너비: 80 cm\n무게: 3 kg",
            "Martian Cruiser\n长度：80 厘米\n宽度：80 厘米\n重量：3 公斤",
            "Martian Cruiser\nDài: 80 cm\nRộng: 80 cm\nNặng: 3 kg"
        },
        new List<string>()
        {
            "Rail Hover GT\nLength: 90 cm\nWidth: 35 cm\nWeight: 0.5 kg",
            "Rail Hover GT\nДлина: 90 cm\nШирина: 35 cm\nВес: 0.5 kg",
            "Rail Hover GT\nLongueur: 90 cm\nLargeur: 35 cm\nPoids: 0.5 kg",
            "Rail Hover GT\nLänge: 90 cm\nBreite: 35 cm\nGewicht: 0.5 kg",
            "Rail Hover GT\nLargo: 90 cm\nAncho: 35 cm\nPeso: 0.5 kg",
            "Rail Hover GT\nComprimento: 90 cm\nLargura: 35 cm\nPeso: 0.5 kg",
            "Rail Hover GT\nالطول: 90 سم \nالعرض: 35 سم \nالوزن: 0.5 كجم",
            "Rail Hover GT\n長さ：90 cm\n幅：35 cm\n重量：0.5 kg",
            "Rail Hover GT\n길이: 90 cm\n너비: 35 cm\n무게: 0.5 kg",
            "Rail Hover GT\n长度：90 厘米\n宽度：35 厘米\n重量：0.5 公斤",
            "Rail Hover GT\nDài: 90 cm\nRộng: 35 cm\nNặng: 0.5 kg"
        },
        new List<string>()
        {
            "Techno Surfer\nLength: 138 cm\nWidth: 38 cm\nWeight: 0.6 kg",
            "Techno Surfer\nДлина: 138 cm\nШирина: 38 cm\nВес: 0.6 kg",
            "Techno Surfer\nLongueur: 138 cm\nLargeur: 38 cm\nPoids: 0.6 kg",
            "Techno Surfer\nLänge: 138 cm\nBreite: 38 cm\nGewicht: 0.6 kg",
            "Techno Surfer\nLargo: 138 cm\nAncho: 38 cm\nPeso: 0.6 kg",
            "Techno Surfer\nComprimento: 138 cm\nLargura: 38 cm\nPeso: 0.6 kg",
            "Techno Surfer\nالطول: 138 سم \nالعرض: 38 سم \nالوزن: 0.6 كجم",
            "Techno Surfer\n長さ：138 cm\n幅：38 cm\n重量：0.6 kg",
            "Techno Surfer\n길이: 138 cm\n너비: 38 cm\n무게: 0.6 kg",
            "Techno Surfer\n长度：138 厘米\n宽度：38 厘米\n重量：0.6 公斤",
            "Techno Surfer\nDài: 138 cm\nRộng: 38 cm\nNặng: 0.6 kg"
        },
        new List<string>()
        {
            "Harvid-Daleyson Special\nLength: 280 cm\nWidth: 78 cm\nWeight: 28 kg",
            "Harvid-Daleyson Special\nДлина: 280 cm\nШирина: 78 cm\nВес: 28 kg",
            "Harvid-Daleyson Special\nLongueur: 280 cm\nLargeur: 78 cm\nPoids: 28 kg",
            "Harvid-Daleyson Special\nLänge: 280 cm\nBreite: 78 cm\nGewicht: 28 kg",
            "Harvid-Daleyson Special\nLargo: 280 cm\nAncho: 78 cm\nPeso: 28 kg",
            "Harvid-Daleyson Special\nComprimento: 280 cm\nLargura: 78 cm\nPeso: 28 kg",
            "Harvid-Daleyson Special\nالطول: 280 سم \nالعرض: 78 سم \nالوزن: 28 كجم",
            "Harvid-Daleyson Special\n長さ：280 cm\n幅：78 cm\n重量：28 kg",
            "Harvid-Daleyson Special\n길이: 280 cm\n너비: 78 cm\n무게: 28 kg",
            "Harvid-Daleyson Special\n长度：280 厘米\n宽度：78 厘米\n重量：28 公斤",
            "Harvid-Daleyson Special\nDài: 280 cm\nRộng: 78 cm\nNặng: 28 kg"
        }
    };
    public static List<List<string>> heroInfoJetpack = new List<List<string>>() { 
        new List<string>() 
        {
            "Glider Jet\nLength: 56 cm\nWidth: 98 cm\nWeight: 5.8 kg",
            "Glider Jet\nДлина: 56 cm\nШирина: 98 cm\nВес: 5.8 kg",
            "Glider Jet\nLongueur: 56 cm\nLargeur: 98 cm\nPoids: 5.8 kg",
            "Glider Jet\nLänge: 56 cm\nBreite: 98 cm\nGewicht: 5.8 kg",
            "Glider Jet\nLargo: 56 cm\nAncho: 98 cm\nPeso: 5.8 kg",
            "Glider Jet\nComprimento: 56 cm\nLargura: 98 cm\nPeso: 5.8 kg",
            "Glider Jet\nالطول: 56 سم \nالعرض: 98 سم \nالوزن: 5.8 كجم",
            "Glider Jet\n長さ：56 cm\n幅：98 cm\n重量：5.8 kg",
            "Glider Jet\n길이: 56 cm\n너비: 98 cm\n무게: 5.8 kg",
            "Glider Jet\n长度：56 厘米\n宽度：98 厘米\n重量：5.8 公斤",
            "Glider Jet\nDài: 56 cm\nRộng: 98 cm\nNặng: 5.8 kg"
        }, 
        new List<string>() 
        {
            "Duo Copter\nLength: 30 cm\nWidth: 100 cm\nWeight: 2.9 kg",
            "Duo Copter\nДлина: 30 cm\nШирина: 100 cm\nВес: 2.9 kg",
            "Duo Copter\nLongueur: 30 cm\nLargeur: 100 cm\nPoids: 2.9 kg",
            "Duo Copter\nLänge: 30 cm\nBreite: 100 cm\nGewicht: 2.9 kg",
            "Duo Copter\nLargo: 30 cm\nAncho: 100 cm\nPeso: 2.9 kg",
            "Duo Copter\nComprimento: 30 cm\nLargura: 100 cm\nPeso: 2.9 kg",
            "Duo Copter\nالطول: 30 سم \nالعرض: 100 سم \nالوزن: 2.9 كجم",
            "Duo Copter\n長さ：30 cm\n幅：100 cm\n重量：2.9 kg",
            "Duo Copter\n길이: 30 cm\n너비: 100 cm\n무게: 2.9 kg",
            "Duo Copter\n长度：30 厘米\n宽度：100 厘米\n重量：2.9 公斤",
            "Duo Copter\nDài: 30 cm\nRộng: 100 cm\nNặng: 2.9 kg"
        }, 
        new List<string>() 
        {
            "Jet' O' Bot\nLength: 70 cm\nWidth: 50 cm\nWeight: 2.8 kg",
            "Jet' O' Bot\nДлина: 70 cm\nШирина: 50 cm\nВес: 2.8 kg",
            "Jet' O' Bot\nLongueur: 70 cm\nLargeur: 50 cm\nPoids: 2.8 kg",
            "Jet' O' Bot\nLänge: 70 cm\nBreite: 50 cm\nGewicht: 2.8 kg",
            "Jet' O' Bot\nLargo: 70 cm\nAncho: 50 cm\nPeso: 2.8 kg",
            "Jet' O' Bot\nComprimento: 70 cm\nLargura: 50 cm\nPeso: 2.8 kg",
            "Jet' O' Bot\nالطول: 70 سم \nالعرض: 50 سم \nالوزن: 2.8 كجم",
            "Jet' O' Bot\n長さ：70 cm\n幅：50 cm\n重量：2.8 kg",
            "Jet' O' Bot\n길이: 70 cm\n너비: 50 cm\n무게: 2.8 kg",
            "Jet' O' Bot\n长度：70 厘米\n宽度：50 厘米\n重量：2.8 公斤",
            "Jet' O' Bot\nDài: 70 cm\nRộng: 50 cm\nNặng: 2.8 kg"
        }, 
        new List<string>() 
        {
            "Air Twister\nLength: 70 cm\nWidth: 85 cm\nWeight: 3.5 kg",
            "Air Twister\nДлина: 70 cm\nШирина: 85 cm\nВес: 3.5 kg",
            "Air Twister\nLongueur: 70 cm\nLargeur: 85 cm\nPoids: 3.5 kg",
            "Air Twister\nLänge: 70 cm\nBreite: 85 cm\nGewicht: 3.5 kg",
            "Air Twister\nLargo: 70 cm\nAncho: 85 cm\nPeso: 3.5 kg",
            "Air Twister\nComprimento: 70 cm\nLargura: 85 cm\nPeso: 3.5 kg",
            "Air Twister\nالطول: 70 سم \nالعرض: 85 سم \nالوزن: 3.5 كجم",
            "Air Twister\n長さ：70 cm\n幅：85 cm\n重量：3.5 kg",
            "Air Twister\n길이: 70 cm\n너비: 85 cm\n무게: 3.5 kg",
            "Air Twister\n长度：70 厘米\n宽度：85 厘米\n重量：3.5 公斤",
            "Air Twister\nDài: 70 cm\nRộng: 85 cm\nNặng: 3.5 kg"
        }, 
        new List<string>() 
        {
            "Air Slicer Neo\nLength: 50 cm\nWidth: 125 cm\nWeight: 1.3 kg",
            "Air Slicer Neo\nДлина: 50 cm\nШирина: 125 cm\nВес: 1.3 kg",
            "Air Slicer Neo\nLongueur: 50 cm\nLargeur: 125 cm\nPoids: 1.3 kg",
            "Air Slicer Neo\nLänge: 50 cm\nBreite: 125 cm\nGewicht: 1.3 kg",
            "Air Slicer Neo\nLargo: 50 cm\nAncho: 125 cm\nPeso: 1.3 kg",
            "Air Slicer Neo\nComprimento: 50 cm\nLargura: 125 cm\nPeso: 1.3 kg",
            "Air Slicer Neo\nالطول: 50 سم \nالعرض: 125 سم \nالوزن: 1.3 كجم",
            "Air Slicer Neo\n長さ：50 cm\n幅：125 cm\n重量：1.3 kg",
            "Air Slicer Neo\n길이: 50 cm\n너비: 125 cm\n무게: 1.3 kg",
            "Air Slicer Neo\n长度：50 厘米\n宽度：125 厘米\n重量：1.3 公斤",
            "Air Slicer Neo\nDài: 50 cm\nRộng: 125 cm\nNặng: 1.3 kg"
        }, 
        new List<string>() 
        {
            "Bat Wraith\nLength: 50 cm\nWidth: 121 cm\nWeight: 0.8 kg",
            "Bat Wraith\nДлина: 50 cm\nШирина: 121 cm\nВес: 0.8 kg",
            "Bat Wraith\nLongueur: 50 cm\nLargeur: 121 cm\nPoids: 0.8 kg",
            "Bat Wraith\nLänge: 50 cm\nBreite: 121 cm\nGewicht: 0.8 kg",
            "Bat Wraith\nLargo: 50 cm\nAncho: 121 cm\nPeso: 0.8 kg",
            "Bat Wraith\nComprimento: 50 cm\nLargura: 121 cm\nPeso: 0.8 kg",
            "Bat Wraith\nالطول: 50 سم \nالعرض: 121 سم \nالوزن: 0.8 كجم",
            "Bat Wraith\n長さ：50 cm\n幅：121 cm\n重量：0.8 kg",
            "Bat Wraith\n길이: 50 cm\n너비: 121 cm\n무게: 0.8 kg",
            "Bat Wraith\n长度：50 厘米\n宽度：121 厘米\n重量：0.8 公斤",
            "Bat Wraith\nDài: 50 cm\nRộng: 121 cm\nNặng: 0.8 kg"
        }, 
        new List<string>() 
        {
            "Angelica\nLength: 55 cm\nWidth: 220 cm\nWeight: 0.2 kg",
            "Angelica\nДлина: 55 cm\nШирина: 220 cm\nВес: 0.2 kg",
            "Angelica\nLongueur: 55 cm\nLargeur: 220 cm\nPoids: 0.2 kg",
            "Angelica\nLänge: 55 cm\nBreite: 220 cm\nGewicht: 0.2 kg",
            "Angelica\nLargo: 55 cm\nAncho: 220 cm\nPeso: 0.2 kg",
            "Angelica\nComprimento: 55 cm\nLargura: 220 cm\nPeso: 0.2 kg",
            "Angelica\nالطول: 55 سم \nالعرض: 220 سم \nالوزن: 0.2 كجم",
            "Angelica\n長さ：55 cm\n幅：220 cm\n重量：0.2 kg",
            "Angelica\n길이: 55 cm\n너비: 220 cm\n무게: 0.2 kg",
            "Angelica\n长度：55 厘米\n宽度：220 厘米\n重量：0.2 公斤",
            "Angelica\nDài: 55 cm\nRộng: 220 cm\nNặng: 0.2 kg"
        }, 
        new List<string>() 
        {
            "Witch's Broom\nLength: 189 cm\nWidth: 20 cm\nWeight: 0.2 kg",
            "Witch's Broom\nДлина: 189 cm\nШирина: 20 cm\nВес: 0.2 kg",
            "Witch's Broom\nLongueur: 189 cm\nLargeur: 20 cm\nPoids: 0.2 kg",
            "Witch's Broom\nLänge: 189 cm\nBreite: 20 cm\nGewicht: 0.2 kg",
            "Witch's Broom\nLargo: 189 cm\nAncho: 20 cm\nPeso: 0.2 kg",
            "Witch's Broom\nComprimento: 189 cm\nLargura: 20 cm\nPeso: 0.2 kg",
            "Witch's Broom\nالطول: 189 سم \nالعرض: 20 سم \nالوزن: 0.2 كجم",
            "Witch's Broom\n長さ：189 cm\n幅：20 cm\n重量：0.2 kg",
            "Witch's Broom\n길이: 189 cm\n너비: 20 cm\n무게: 0.2 kg",
            "Witch's Broom\n长度：189 厘米\n宽度：20 厘米\n重量：0.2 公斤",
            "Witch's Broom\nDài: 189 cm\nRộng: 20 cm\nNặng: 0.2 kg"
        }
    };
    public static List<List<string>> heroInfoBoat = new List<List<string>>() { 
        new List<string>() 
        {
            "Crawdad\nLength: 260 cm\nWidth: 80 cm\nWeight: 24 kg",
            "Crawdad\nДлина: 260 cm\nШирина: 80 cm\nВес: 24 kg",
            "Crawdad\nLongueur: 260 cm\nLargeur: 80 cm\nPoids: 24 kg",
            "Crawdad\nLänge: 260 cm\nBreite: 80 cm\nGewicht: 24 kg",
            "Crawdad\nLargo: 260 cm\nAncho: 80 cm\nPeso: 24 kg",
            "Crawdad\nComprimento: 260 cm\nLargura: 80 cm\nPeso: 24 kg",
            "Crawdad\nالطول: 260 سم \nالعرض: 80 سم \nالوزن: 24 كجم",
            "Crawdad\n長さ：260 cm\n幅：80 cm\n重量：24 kg",
            "Crawdad\n길이: 260 cm\n너비: 80 cm\n무게: 24 kg",
            "Crawdad\n长度：260 厘米\n宽度：80 厘米\n重量：24 公斤",
            "Crawdad\nDài: 260 cm\nRộng: 80 cm\nNặng: 24 kg"
        },
        new List<string>() 
        {
            "Argo\nLength: 220 cm\nWidth: 78 cm\nWeight: 28 kg",
            "Argo\nДлина: 220 cm\nШирина: 78 cm\nВес: 28 kg",
            "Argo\nLongueur: 220 cm\nLargeur: 78 cm\nPoids: 28 kg",
            "Argo\nLänge: 220 cm\nBreite: 78 cm\nGewicht: 28 kg",
            "Argo\nLargo: 220 cm\nAncho: 78 cm\nPeso: 28 kg",
            "Argo\nComprimento: 220 cm\nLargura: 78 cm\nPeso: 28 kg",
            "Argo\nالطول: 220 سم \nالعرض: 78 سم \nالوزن: 28 كجم",
            "Argo\n長さ：220 cm\n幅：78 cm\n重量：28 kg",
            "Argo\n길이: 220 cm\n너비: 78 cm\n무게: 28 kg",
            "Argo\n长度：220 厘米\n宽度：78 厘米\n重量：28 公斤",
            "Argo\nDài: 220 cm\nRộng: 78 cm\nNặng: 28 kg"
        },
        new List<string>() 
        {
            "Wet Affair\nLength: 240 cm\nWidth: 75 cm\nWeight: 26 kg",
            "Wet Affair\nДлина: 240 cm\nШирина: 75 cm\nВес: 26 kg",
            "Wet Affair\nLongueur: 240 cm\nLargeur: 75 cm\nPoids: 26 kg",
            "Wet Affair\nLänge: 240 cm\nBreite: 75 cm\nGewicht: 26 kg",
            "Wet Affair\nLargo: 240 cm\nAncho: 75 cm\nPeso: 26 kg",
            "Wet Affair\nComprimento: 240 cm\nLargura: 75 cm\nPeso: 26 kg",
            "Wet Affair\nالطول: 240 سم \nالعرض: 75 سم \nالوزن: 26 كجم",
            "Wet Affair\n長さ：240 cm\n幅：75 cm\n重量：26 kg",
            "Wet Affair\n길이: 240 cm\n너비: 75 cm\n무게: 26 kg",
            "Wet Affair\n长度：240 厘米\n宽度：75 厘米\n重量：26 公斤",
            "Wet Affair\nDài: 240 cm\nRộng: 75 cm\nNặng: 26 kg"
        },
        new List<string>() 
        {
            "Aqua Nauti\nLength: 300 cm\nWidth: 96 cm\nWeight: 16 kg",
            "Aqua Nauti\nДлина: 300 cm\nШирина: 96 cm\nВес: 16 kg",
            "Aqua Nauti\nLongueur: 300 cm\nLargeur: 96 cm\nPoids: 16 kg",
            "Aqua Nauti\nLänge: 300 cm\nBreite: 96 cm\nGewicht: 16 kg",
            "Aqua Nauti\nLargo: 300 cm\nAncho: 96 cm\nPeso: 16 kg",
            "Aqua Nauti\nComprimento: 300 cm\nLargura: 96 cm\nPeso: 16 kg",
            "Aqua Nauti\nالطول: 300 سم \nالعرض: 96 سم \nالوزن: 16 كجم",
            "Aqua Nauti\n長さ：300 cm\n幅：96 cm\n重量：16 kg",
            "Aqua Nauti\n길이: 300 cm\n너비: 96 cm\n무게: 16 kg",
            "Aqua Nauti\n长度：300 厘米\n宽度：96 厘米\n重量：16 公斤",
            "Aqua Nauti\nDài: 300 cm\nRộng: 96 cm\nNặng: 16 kg"
        },
        new List<string>() 
        {
            "Crewshell\nLength: 260 cm\nWidth: 100 cm\nWeight: 18 kg",
            "Crewshell\nДлина: 260 cm\nШирина: 100 cm\nВес: 18 kg",
            "Crewshell\nLongueur: 260 cm\nLargeur: 100 cm\nPoids: 18 kg",
            "Crewshell\nLänge: 260 cm\nBreite: 100 cm\nGewicht: 18 kg",
            "Crewshell\nLargo: 260 cm\nAncho: 100 cm\nPeso: 18 kg",
            "Crewshell\nComprimento: 260 cm\nLargura: 100 cm\nPeso: 18 kg",
            "Crewshell\nالطول: 260 سم \nالعرض: 100 سم \nالوزن: 18 كجم",
            "Crewshell\n長さ：260 cm\n幅：100 cm\n重量：18 kg",
            "Crewshell\n길이: 260 cm\n너비: 100 cm\n무게: 18 kg",
            "Crewshell\n长度：260 厘米\n宽度：100 厘米\n重量：18 公斤",
            "Crewshell\nDài: 260 cm\nRộng: 100 cm\nNặng: 18 kg"
        },
        new List<string>() 
        {
            "Hula\nLength: 150 cm\nWidth: 90 cm\nWeight: 13 kg",
            "Hula\nДлина: 150 cm\nШирина: 90 cm\nВес: 13 kg",
            "Hula\nLongueur: 150 cm\nLargeur: 90 cm\nPoids: 13 kg",
            "Hula\nLänge: 150 cm\nBreite: 90 cm\nGewicht: 13 kg",
            "Hula\nLargo: 150 cm\nAncho: 90 cm\nPeso: 13 kg",
            "Hula\nComprimento: 150 cm\nLargura: 90 cm\nPeso: 13 kg",
            "Hula\nالطول: 150 سم \nالعرض: 90 سم \nالوزن: 13 كجم",
            "Hula\n長さ：150 cm\n幅：90 cm\n重量：13 kg",
            "Hula\n길이: 150 cm\n너비: 90 cm\n무게: 13 kg",
            "Hula\n长度：150 厘米\n宽度：90 厘米\n重量：13 公斤",
            "Hula\nDài: 150 cm\nRộng: 90 cm\nNặng: 13 kg"
        },
        new List<string>() 
        {
            "Bigs\nLength: 290 cm\nWidth: 130 cm\nWeight: 34 kg",
            "Bigs\nДлина: 290 cm\nШирина: 130 cm\nВес: 34 kg",
            "Bigs\nLongueur: 290 cm\nLargeur: 130 cm\nPoids: 34 kg",
            "Bigs\nLänge: 290 cm\nBreite: 130 cm\nGewicht: 34 kg",
            "Bigs\nLargo: 290 cm\nAncho: 130 cm\nPeso: 34 kg",
            "Bigs\nComprimento: 290 cm\nLargura: 130 cm\nPeso: 34 kg",
            "Bigs\nالطول: 290 سم \nالعرض: 130 سم \nالوزن: 34 كجم",
            "Bigs\n長さ：290 cm\n幅：130 cm\n重量：34 kg",
            "Bigs\n길이: 290 cm\n너비: 130 cm\n무게: 34 kg",
            "Bigs\n长度：290 厘米\n宽度：130 厘米\n重量：34 公斤",
            "Bigs\nDài: 290 cm\nRộng: 130 cm\nNặng: 34 kg"
        },
        new List<string>() 
        {
            "Oceanrunner\nLength: 270 cm\nWidth: 89 cm\nWeight: 35 kg",
            "Oceanrunner\nДлина: 270 cm\nШирина: 89 cm\nВес: 35 kg",
            "Oceanrunner\nLongueur: 270 cm\nLargeur: 89 cm\nPoids: 35 kg",
            "Oceanrunner\nLänge: 270 cm\nBreite: 89 cm\nGewicht: 35 kg",
            "Oceanrunner\nLargo: 270 cm\nAncho: 89 cm\nPeso: 35 kg",
            "Oceanrunner\nComprimento: 270 cm\nLargura: 89 cm\nPeso: 35 kg",
            "Oceanrunner\nالطول: 270 سم \nالعرض: 89 سم \nالوزن: 35 كجم",
            "Oceanrunner\n長さ：270 cm\n幅：89 cm\n重量：35 kg",
            "Oceanrunner\n길이: 270 cm\n너비: 89 cm\n무게: 35 kg",
            "Oceanrunner\n长度：270 厘米\n宽度：89 厘米\n重量：35 公斤",
            "Oceanrunner\nDài: 270 cm\nRộng: 89 cm\nNặng: 35 kg"
        },
        new List<string>() 
        {
            "Strider\nLength: 155 cm\nWidth: 69 cm\nWeight: 28 kg",
            "Strider\nДлина: 155 cm\nШирина: 69 cm\nВес: 28 kg",
            "Strider\nLongueur: 155 cm\nLargeur: 69 cm\nPoids: 28 kg",
            "Strider\nLänge: 155 cm\nBreite: 69 cm\nGewicht: 28 kg",
            "Strider\nLargo: 155 cm\nAncho: 69 cm\nPeso: 28 kg",
            "Strider\nComprimento: 155 cm\nLargura: 69 cm\nPeso: 28 kg",
            "Strider\nالطول: 155 سم \nالعرض: 69 سم \nالوزن: 28 كجم",
            "Strider\n長さ：155 cm\n幅：69 cm\n重量：28 kg",
            "Strider\n길이: 155 cm\n너비: 69 cm\n무게: 28 kg",
            "Strider\n长度：155 厘米\n宽度：69 厘米\n重量：28 公斤",
            "Strider\nDài: 155 cm\nRộng: 69 cm\nNặng: 28 kg"
        },
        new List<string>() 
        {
            "Whopper\nLength: 310 cm\nWidth: 96 cm\nWeight: 38 kg",
            "Whopper\nДлина: 310 cm\nШирина: 96 cm\nВес: 38 kg",
            "Whopper\nLongueur: 310 cm\nLargeur: 96 cm\nPoids: 38 kg",
            "Whopper\nLänge: 310 cm\nBreite: 96 cm\nGewicht: 38 kg",
            "Whopper\nLargo: 310 cm\nAncho: 96 cm\nPeso: 38 kg",
            "Whopper\nComprimento: 310 cm\nLargura: 96 cm\nPeso: 38 kg",
            "Whopper\nالطول: 310 سم \nالعرض: 96 سم \nالوزن: 38 كجم",
            "Whopper\n長さ：310 cm\n幅：96 cm\n重量：38 kg",
            "Whopper\n길이: 310 cm\n너비: 96 cm\n무게: 38 kg",
            "Whopper\n长度：310 厘米\n宽度：96 厘米\n重量：38 公斤",
            "Whopper\nDài: 310 cm\nRộng: 96 cm\nNặng: 38 kg"
        },
        new List<string>() 
        {
            "Charm\nLength: 240 cm\nWidth: 58 cm\nWeight: 18 kg",
            "Charm\nДлина: 240 cm\nШирина: 58 cm\nВес: 18 kg",
            "Charm\nLongueur: 240 cm\nLargeur: 58 cm\nPoids: 18 kg",
            "Charm\nLänge: 240 cm\nBreite: 58 cm\nGewicht: 18 kg",
            "Charm\nLargo: 240 cm\nAncho: 58 cm\nPeso: 18 kg",
            "Charm\nComprimento: 240 cm\nLargura: 58 cm\nPeso: 18 kg",
            "Charm\nالطول: 240 سم \nالعرض: 58 سم \nالوزن: 18 كجم",
            "Charm\n長さ：240 cm\n幅：58 cm\n重量：18 kg",
            "Charm\n길이: 240 cm\n너비: 58 cm\n무게: 18 kg",
            "Charm\n长度：240 厘米\n宽度：58 厘米\n重量：18 公斤",
            "Charm\nDài: 240 cm\nRộng: 58 cm\nNặng: 18 kg"
        },
        new List<string>() 
        {
            "Breezin\nLength: 200 cm\nWidth: 80 cm\nWeight: 28 kg",
            "Breezin\nДлина: 200 cm\nШирина: 80 cm\nВес: 28 kg",
            "Breezin\nLongueur: 200 cm\nLargeur: 80 cm\nPoids: 28 kg",
            "Breezin\nLänge: 200 cm\nBreite: 80 cm\nGewicht: 28 kg",
            "Breezin\nLargo: 200 cm\nAncho: 80 cm\nPeso: 28 kg",
            "Breezin\nComprimento: 200 cm\nLargura: 80 cm\nPeso: 28 kg",
            "Breezin\nالطول: 200 سم \nالعرض: 80 سم \nالوزن: 28 كجم",
            "Breezin\n長さ：200 cm\n幅：80 cm\n重量：28 kg",
            "Breezin\n길이: 200 cm\n너비: 80 cm\n무게: 28 kg",
            "Breezin\n长度：200 厘米\n宽度：80 厘米\n重量：28 公斤",
            "Breezin\nDài: 200 cm\nRộng: 80 cm\nNặng: 28 kg"
        },
        new List<string>() 
        {
            "Neptunes Grail\nLength: 300 cm\nWidth: 112 cm\nWeight: 28 kg",
            "Neptunes Grail\nДлина: 300 cm\nШирина: 112 cm\nВес: 28 kg",
            "Neptunes Grail\nLongueur: 300 cm\nLargeur: 112 cm\nPoids: 28 kg",
            "Neptunes Grail\nLänge: 300 cm\nBreite: 112 cm\nGewicht: 28 kg",
            "Neptunes Grail\nLargo: 300 cm\nAncho: 112 cm\nPeso: 28 kg",
            "Neptunes Grail\nComprimento: 300 cm\nLargura: 112 cm\nPeso: 28 kg",
            "Neptunes Grail\nالطول: 300 سم \nالعرض: 112 سم \nالوزن: 28 كجم",
            "Neptunes Grail\n長さ：300 cm\n幅：112 cm\n重量：28 kg",
            "Neptunes Grail\n길이: 300 cm\n너비: 112 cm\n무게: 28 kg",
            "Neptunes Grail\n长度：300 厘米\n宽度：112 厘米\n重量：28 公斤",
            "Neptunes Grail\nDài: 300 cm\nRộng: 112 cm\nNặng: 28 kg"
        },
        new List<string>() 
        {
            "Water Sled\nLength: 340 cm\nWidth: 118 cm\nWeight: 35 kg",
            "Water Sled\nДлина: 340 cm\nШирина: 118 cm\nВес: 35 kg",
            "Water Sled\nLongueur: 340 cm\nLargeur: 118 cm\nPoids: 35 kg",
            "Water Sled\nLänge: 340 cm\nBreite: 118 cm\nGewicht: 35 kg",
            "Water Sled\nLargo: 340 cm\nAncho: 118 cm\nPeso: 35 kg",
            "Water Sled\nComprimento: 340 cm\nLargura: 118 cm\nPeso: 35 kg",
            "Water Sled\nالطول: 340 سم \nالعرض: 118 سم \nالوزن: 35 كجم",
            "Water Sled\n長さ：340 cm\n幅：118 cm\n重量：35 kg",
            "Water Sled\n길이: 340 cm\n너비: 118 cm\n무게: 35 kg",
            "Water Sled\n长度：340 厘米\n宽度：118 厘米\n重量：35 公斤",
            "Water Sled\nDài: 340 cm\nRộng: 118 cm\nNặng: 35 kg"
        },
        new List<string>() 
        {
            "Bandit\nLength: 300 cm\nWidth: 100 cm\nWeight: 30 kg",
            "Bandit\nДлина: 300 cm\nШирина: 100 cm\nВес: 30 kg",
            "Bandit\nLongueur: 300 cm\nLargeur: 100 cm\nPoids: 30 kg",
            "Bandit\nLänge: 300 cm\nBreite: 100 cm\nGewicht: 30 kg",
            "Bandit\nLargo: 300 cm\nAncho: 100 cm\nPeso: 30 kg",
            "Bandit\nComprimento: 300 cm\nLargura: 100 cm\nPeso: 30 kg",
            "Bandit\nالطول: 300 سم \nالعرض: 100 سم \nالوزن: 30 كجم",
            "Bandit\n長さ：300 cm\n幅：100 cm\n重量：30 kg",
            "Bandit\n길이: 300 cm\n너비: 100 cm\n무게: 30 kg",
            "Bandit\n长度：300 厘米\n宽度：100 厘米\n重量：30 公斤",
            "Bandit\nDài: 300 cm\nRộng: 100 cm\nNặng: 30 kg"
        },
        new List<string>() 
        {
            "Escapade\nLength: 206 cm\nWidth: 80 cm\nWeight: 38 kg",
            "Escapade\nДлина: 206 cm\nШирина: 80 cm\nВес: 38 kg",
            "Escapade\nLongueur: 206 cm\nLargeur: 80 cm\nPoids: 38 kg",
            "Escapade\nLänge: 206 cm\nBreite: 80 cm\nGewicht: 38 kg",
            "Escapade\nLargo: 206 cm\nAncho: 80 cm\nPeso: 38 kg",
            "Escapade\nComprimento: 206 cm\nLargura: 80 cm\nPeso: 38 kg",
            "Escapade\nالطول: 206 سم \nالعرض: 80 سم \nالوزن: 38 كجم",
            "Escapade\n長さ：206 cm\n幅：80 cm\n重量：38 kg",
            "Escapade\n길이: 206 cm\n너비: 80 cm\n무게: 38 kg",
            "Escapade\n长度：206 厘米\n宽度：80 厘米\n重量：38 公斤",
            "Escapade\nDài: 206 cm\nRộng: 80 cm\nNặng: 38 kg"
        }
    };
    public static List<string> heroSpeedSkis = new List<string>() 
    { 
        "Speed:", 
        "Скорость:",
        "Vitesse:", 
        "Geschwindigkeit:",
        "Velocidad:", 
        "Velocidade:",
        ":السرعة", 
        "速度：",
        "속도:",
        "速度：",
        "Tốc độ:" 
    };

    //IN PAGE TOP/ACHIEVEMENT
    public static List<string> topScore = new List<string>() 
    { 
        "SCORE", 
        "СЧЕТ",
        "SCORE", 
        "SCORE",
        "SCORE", 
        "PONTOS",
        "النقاط", 
        "スコア",
        "점수",
        "得分",
        "ĐIỂM" 
    };
    public static List<string> topNoName = new List<string>() 
    { 
        "No name", 
        "Без имени", 
        "Aucun nom",
        "Kein name", 
        "Sin nombre", 
        "Sem nome",
        "لا يوجد اسم", 
        "名前なし", 
        "이름 없음", 
        "没有名字", 
        "Vô danh" 
    };
    public static List<string> topDoubleCoin = new List<string>() 
    { 
        "Double diamonds", 
        "Удвоить бриллианты", 
        "Doubler les pièces", 
        "Münzen verdoppeln",
        "Diamantes dobles",
        "Dobre os diamantes",
        "ضاعف الألماس", 
        "ダブルダイアモンド", 
        "더블 코인",
        "双倍钻石", 
        "2X kim cương" 
    };
    public static List<string> topLoading = new List<string>() 
    { 
        "Loading", 
        "Загрузка", 
        "Chargement",
        "Lädt",
        "Cargando", 
        "Carregando",
        "جار التحميل", 
        "読み込み中", 
        "로드 중",
        "载入中",
        "Đang tải" 
    };
    public static List<string> topTopYourself = new List<string>() 
    { 
        "YOURSELF", 
        "YOURSELF", 
        "YOURSELF",
        "YOURSELF",
        "YOURSELF",
        "YOURSELF", 
        "YOURSELF",
        "YOURSELF",
        "YOURSELF",
        "YOURSELF", 
        "BẢN THÂN" 
    };
    public static List<string> topTopFriend = new List<string>() 
    { 
        "FRIEND", 
        "ДРУЗЕЙ", 
        "AMI",
        "FREUND",
        "AMIGO",
        "AMIGO", 
        "صديق",
        "友達",
        "친구",
        "朋友", 
        "BẠN BÈ" 
    };
    public static List<string> topTopCountry = new List<string>() 
    { 
        "COUNTRY", 
        "СТРАНЫ", 
        "PAYS",
        "LAND",
        "PAÍS",
        "PAÍS", 
        "البلد",
        "国", 
        "국가",
        "国家",
        "QUỐC GIA" 
    };
    public static List<string> topTopWorld = new List<string>() 
    { 
        "WORLD", 
        "МИРА", 
        "MONDE",
        "WELT",
        "MUNDO",
        "MUNDO", 
        "العالم",
        "世界", 
        "월드",
        "世界",
        "THẾ GIỚI" 
    };
    public static List<string> topTopDogecoin = new List<string>()
    {
        "DOGECOIN",
        "DOGECOIN",
        "DOGECOIN",
        "DOGECOIN",
        "DOGECOIN",
        "DOGECOIN",
        "DOGECOIN",
        "DOGECOIN",
        "DOGECOIN",
        "DOGECOIN",
        "DOGECOIN"
    };
    public static List<string> topLoginFacebook = new List<string>() 
    { 
        "FACEBOOK LOG IN", 
        "ВОЙТИ ЧЕРЕЗ ФЕЙСБУК", 
        "CONNEXION VIA FACEBOOK",
        "FACEBOOK ANMELDUNG",
        "ENTRAR FACEBOOK",
        "ENTRAR COM FACEBOOK", 
        "تسجيل دخول FACEBOOK", 
        "Facebook ログイン", 
        "로그인 FACEBOOK", 
        "登入面子书", 
        "ĐĂNG NHẬP FACEBOOK" 
    };
    public static List<string> topWeek = new List<string>() 
    { 
        "WEEK", 
        "WEEK", 
        "WEEK",
        "WEEK",
        "WEEK",
        "WEEK", 
        "WEEK", 
        "WEEK", 
        "WEEK", 
        "WEEK", 
        "TUẦN" 
    };
    public static List<string> topTimeLeft = new List<string>() 
    { 
        "Time left", 
        "Time left", 
        "Time left",
        "Time left",
        "Time left",
        "Time left", 
        "Time left", 
        "Time left", 
        "Time left", 
        "Time left", 
        "Còn lại" 
    };
    //GET XXX COINS RIGHT AWAY
    public static List<string> topNoteGetStart = new List<string>() 
    { 
        "GET", 
        "ПОЛУЧИТЬ", 
        "OBTENIR", 
        "BEKOMME",
        "OBTENER", 
        "OBTER", 
        "أحصل علي", 
        "獲得する", 
        "받다", 
        "得到", 
        "NHẬN" 
    };
    public static List<string> topNoteGetEnd = new List<string>() 
    { 
        "DIAMONDS IMMEDIATELY", 
        "БРИЛЛИАНТОВ СРАЗУ", 
        "DES PIÈCES IMMÉDIATEMENT",
        "MÜNZEN SOFORT",
        "DIAMANTES INMEDIATAMENTE", 
        "DIAMANTES IMEDIATAMENTE", 
        "القطع النقدية فورا", 
        "直ちに ダイアモンド", 
        "코인 즉시", 
        "立即钻石", 
        "XU NGAY BÂY GIỜ" 
    };

    //IN PAGE RANK
    public static List<string> rankLegendary = new List<string>() 
    { 
        "LEGENDARY", 
        "LEGENDARY", 
        "LEGENDARY",
        "LEGENDARY",
        "LEGENDARY", 
        "LEGENDARY",
        "LEGENDARY",
        "LEGENDARY", 
        "LEGENDARY", 
        "LEGENDARY", 
        "HUYỀN THOẠI" 
    };
    public static List<string> rankDiamond = new List<string>() 
    { 
        "DIAMOND", 
        "DIAMOND", 
        "DIAMOND",
        "DIAMOND",
        "DIAMOND", 
        "DIAMOND",
        "DIAMOND",
        "DIAMOND", 
        "DIAMOND", 
        "DIAMOND", 
        "KIM CƯƠNG" 
    };
    public static List<string> rankGold = new List<string>() 
    { 
        "GOLD", 
        "GOLD", 
        "GOLD",
        "GOLD",
        "GOLD", 
        "GOLD",
        "GOLD",
        "GOLD", 
        "GOLD", 
        "GOLD", 
        "VÀNG" 
    };
    public static List<string> rankSilver = new List<string>() 
    { 
        "SILVER", 
        "SILVER", 
        "SILVER",
        "SILVER",
        "SILVER", 
        "SILVER",
        "SILVER",
        "SILVER", 
        "SILVER", 
        "SILVER", 
        "BẠC" 
    };

    //IN PAGE SHOP ITEM
    public static List<string> shopButtonBuy = new List<string>() 
    { 
        "BUY", 
        "КУПИТЬ",
        "ACHETER",
        "KAUFEN",
        "COMPRAR", 
        "COMPRAR", 
        "شراء", 
        "購入する", 
        "사다", 
        "购买", 
        "MUA" 
    };
    public static List<string> shopBuyItem = new List<string>() 
    { 
        "BUY ITEMS", 
        "КУПИТЬ",
        "ACHETER",
        "KAUFEN",
        "COMPRAR",
        "COMPRAR", 
        "شراء العناصر", 
        "商品を 購入する",
        "품목 구입", 
        "购买物品", 
        "MUA VẬT PHẨM" 
    };
    public static List<string> shopUpgrades = new List<string>() 
    { 
        "UPGRADES", 
        "АПГРЕЙДЫ", 
        "AMÉLIORATIONS",
        "UPGRADES",
        "MEJORAS", 
        "ATUALIZAÇÕES",
        "تحديث",
        "アップグレード", 
        "업 그레 이드", 
        "升级", 
        "NÂNG CẤP" 
    };
    public static List<string> shopSupportItem = new List<string>() 
    { 
        "SPECIAL OFFERS", 
        "СПЕЦИАЛЬНЫЕ ПРЕДЛОЖЕНИЯ", 
        "SPECIAL OFFERS", 
        "SPECIAL OFFERS",
        "SPECIAL OFFERS",
        "SPECIAL OFFERS", 
        "SPECIAL OFFERS",
        "SPECIAL OFFERS",
        "SPECIAL OFFERS", 
        "SPECIAL OFFERS",
        "ƯU ĐÃI ĐẶC BIỆT" 
    };
    public static List<string> shopBuyCoin = new List<string>() 
    { 
        "BUY DIAMONDS", 
        "КУПИТЬ БРИЛЛИАНТЫ", 
        "ACHETER DES PIÈCES", 
        "MÜNZEN KAUFEN",
        "COMPRAR DIAMANTES",
        "COMPRAR DIAMANTES", 
        "شراء عملات",
        "ダイアモンドを 購入",
        "코인 구매", 
        "购买钻石",
        "MUA KIM CƯƠNG" 
    };
    public static List<string> shopBuyKey = new List<string>() 
    { 
        "BUY KEYS", 
        "КУПИТЬ КЛЮЧИ", 
        "ACHETER DES CLÉS",
        "SCHLÜSSEL KAUFEN",
        "COMPRAR LLAVES",
        "COMPRAR CHAVES",
        "شراء مفاتيح", 
        "キーを 購入する",
        "키 구입", 
        "购买钥匙", 
        "MUA CHÌA KHÓA" 
    };
    public static List<string> shopSingleUse = new List<string>() 
    { 
        "SINGLE USE", 
        "ОДНОРАЗОВЫЙ", 
        "USAGE UNIQUE", 
        "EINZELBENUTZUNG", 
        "USO ÚNICO", 
        "USO ÚNICO",
        "استعمال فردي", 
        "単回使用", 
        "단일 사용", 
        "仅供单次使用", 
        "HÀNG PHỔ DỤNG" 
    };
    public static List<string> shopTotal = new List<string>() 
    { 
        "Total:", 
        "Всего:", 
        "Total:",
        "Gesamt:",
        "Totalizar:",
        "Total:", 
        "إجمالي:",
        "合計：", 
        "합계:",
        "总共：", 
        "Tổng:" 
    };
    public static List<string> shopUseRight = new List<string>() 
    { 
        "Use right after purchase", 
        "Доступно сразу", 
        "Utiliser après l'achat",
        "Sofort nach dem Kauf benutzen",
        "Uso justo después de compra", 
        "Use logo após a compra", 
        "استخدام بعد الشراء", 
        "購入後に 使用する", 
        "구매 후 사용", 
        "购买后立即使用", 
        "Dùng ngay sau khi mua" 
    };
    public static List<string> shopNotEnough = new List<string>() 
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
    public static List<string> shopMaxLevel = new List<string>() 
    { 
        "Maximum level", 
        "Максимальный уровень", 
        "Niveau maximum",
        "Höchster Level",
        "Nivel máximo", 
        "Nível máximo", 
        "الحد الأقصى", 
        "最大 レベル",
        "최대 레벨", 
        "最高级别",
        "Cấp độ tối đa" 
    };
    public static List<string> shopMaxNumber = new List<string>() 
    { 
        "Maximum number", 
        "Максимальный", 
        "Nombre maximum",
        "Maximale Anzahl",
        "Número máximo", 
        "Número máximo", 
        "أقصى عدد",  
        "最大数",
        "최대 수", 
        "最大数量", 
        "Số lượng tối đa" 
    };
    public static List<List<string>> shopPackage = new List<List<string>>() { 
        new List<string>() 
        {
            "SMALL PACKAGE", 
            "МАЛЫЙ НАБОР", 
            "PETIT PAQUET",
            "KLEINES PAKET",
            "PAQUETE PEQUEÑO",
            "PACOTE PEQUENO", 
            "حزمة صغيرة", 
            "小 パッケージ", 
            "소규모 패키지", 
            "小包装", 
            "GÓI NHỎ" 
        }, 
        new List<string>() 
        {
            "BIG PACKAGE", 
            "БОЛЬШОЙ ПАКЕТ", 
            "PAQUET NORMAL", 
            "NORMALES PAKET",
            "PAQUETE NORMAL", 
            "PACOTE NORMAL",
            "حزمة عادية", 
            "大 パッケージ", 
            "일반 패키지",
            "大包装",
            "GÓI THƯỜNG" 
        },
        new List<string>() 
        {
            "LAVISH PACKAGE", 
            "ОГРОМНЫЙ СУНДУК", 
            "PAQUET SOMPTUEUX", 
            "GROSSES PAKET",
            "PAQUETE GRANDE", 
            "PACOTE GRANDE", 
            "حزمة كبيرة",
            "豪華 パッケージ", 
            "큰 패키지", 
            "奢华包装",
            "GÓI LỚN" 
        },
        new List<string>() 
        {
            "DOUBLE DIAMONDS", 
            "УДВОЙ АЛМАЗЫ", 
            "DOUBLE DIAMONDS", 
            "DOUBLE DIAMONDS",
            "DOUBLE DIAMONDS", 
            "DOUBLE DIAMONDS", 
            "DOUBLE DIAMONDS",
            "DOUBLE DIAMONDS", 
            "DOUBLE DIAMONDS", 
            "DOUBLE DIAMONDS",
            "NHÂN ĐÔI KIM CƯƠNG" 
        },
        new List<string>() 
        {
            "STARTER PACK", 
            "СТАРТОВЫЙ ПАКЕТ", 
            "STARTER PACK", 
            "STARTER PACK",
            "STARTER PACK", 
            "STARTER PACK", 
            "STARTER PACK",
            "STARTER PACK", 
            "STARTER PACK", 
            "STARTER PACK",
            "GÓI KHỞI ĐẦU" 
        }
    };
    public static List<string> shopDoubleCoin = new List<string>() 
    { 
        "Double all Diamond pickups.", 
        "Все собранные бриллианты считаются в двойном объеме.",
        "Double all Diamond pickups.", 
        "Double all Diamond pickups.", 
        "Double all Diamond pickups.", 
        "Double all Diamond pickups.", 
        "Double all Diamond pickups.", 
        "Double all Diamond pickups.", 
        "Double all Diamond pickups.",
        "Double all Diamond pickups.", 
        "Nhân đôi giá trị của tất cả kim cương nhặt được." 
    };
    public static List<string> shopStarterPack = new List<string>() 
    { 
        "Super value in a box.", 
        "Супер набор в коробке.",
        "Super value in a box.", 
        "Super value in a box.", 
        "Super value in a box.", 
        "Super value in a box.", 
        "Super value in a box.", 
        "Super value in a box.", 
        "Super value in a box.",
        "Super value in a box.", 
        "Có giá trị lớn trong hộp" 
    };
    //You will have XXX diamonds right after the purchase.
    public static List<string> shopStartPurchase = new List<string>() 
    { 
        "You will have", 
        "У тебя будет",
        "Vous aurez", 
        "Du wirst", 
        "Usted tendrá", 
        "Voce terá", 
        "سيكون لديك", 
        "あなたは 持っているでしょう", 
        "당신은 할 것",
        "你将会拥有", 
        "Bạn sẽ có" 
    };
    public static List<string> shopEndCoinPurchase = new List<string>() 
    { 
        "diamonds right after the purchase.", 
        "БРИЛЛИАНТОВ сразу после покупки.", 
        "pièces après l'achat.", 
        "münzen nach dem Kauf haben.", 
        "diamantes justo después de la compra.", 
        "diamantes logo após a compra.", 
        "القطع النقدية الحق بعد الشراء.", 
        "購入直後の ダイアモンド", 
        "구매 후 동전.", 
        "购买后的钻石。", 
        "kim cương ngay sau khi mua hàng." 
    };
    public static List<string> shopEndKeysPurchase = new List<string>() 
    { 
        "keys right after the purchase.", 
        "Ключей сразу после покупки.",
        "clés après l'achat.",
        "schlüssel nach dem Kauf.", 
        "llaves justo después de la compra.",
        "chaves logo após a compra.", 
        "مفاتيح الحق بعد الشراء.", 
        "購入直後の キー", 
        "구매 후 열쇠.", 
        "购买后的钥匙。", 
        "chìa khóa ngay sau khi mua hàng." 
    };
    public static List<string> shopHoverboard = new List<string>() 
    { 
        "HOVERBOARD", 
        "ДОСКА",
        "HOVERBOARD",
        "HOVERBOARD", 
        "HOVERBOARD", 
        "HOVERBOARD",
        "HOVERBOARD",
        "ホバーボード", 
        "HOVERBOARD",
        "悬浮滑板", 
        "VÁN BAY" 
    };
    public static List<string> shopJetBall = new List<string>() 
    { 
        "BALLOONE", 
        "BALLOONE",
        "BALLOONE",
        "BALLOONE", 
        "GLOBO", 
        "BALÃO",
        "BALLOONE",
        "バルーン", 
        "BALLOONE",
        "气球", 
        "KHÍ CẦU" 
    };
    public static List<string> shopDouble = new List<string>() 
    { 
        "DIAMOND FRENZY", 
        "DIAMOND FRENZY",
        "DIAMOND FRENZY",
        "DIAMOND FRENZY", 
        "DIAMOND FRENZY", 
        "DIAMOND FRENZY",
        "DIAMOND FRENZY",
        "DIAMOND FRENZY", 
        "DIAMOND FRENZY",
        "DIAMOND FRENZY", 
        "KIM CƯƠNG TRẮNG" 
    };
    public static List<string> shopChestBox = new List<string>() 
    { 
        "SAFE BOX", 
        "СЕЙФ", 
        "COFFRE",
        "SCHATZKISTE", 
        "COFRE DEL TESORO",
        "BAÚ", 
        "SAFE BOX", 
        "チェストボックス",
        "SAFE BOX",
        "宝箱",
        "RƯƠNG BÍ ẨN" 
    };
    public static List<string> shopHeadStart = new List<string>() 
    { 
        "HEADSTART", 
        "HEADSTART", 
        "AVANCE",
        "VORSPRUNG",
        "COMIENZAPRIMERO",
        "COMEÇAR NA FRENTE", 
        "HEADSTART", 
        "ヘッドスタート",
        "HEADSTART",
        "开启器", 
        "GỌI XE BAY" 
    };
    public static List<string> shopScoreBooster = new List<string>() 
    { 
        "SCOREBOOSTER", 
        "УМНОЖИТЕЛЬ ОЧКОВ",
        "BOOSTEUR DE SCORE",
        "PUNKTEBOOSTER",
        "CONSIGUEPUNTOS",
        "IMPULSIONAR PONTUAÇÃO",
        "SCOREBOOSTER",
        "スコアブースター",
        "SCOREBOOSTER",
        "得分助推器", 
        "ĐIỂM CỘNG" 
    };
    public static List<string> shopWheelSpin = new List<string>() 
    { 
        "SPIN WHEEL", 
        "КОЛЕСО УДАЧИ", 
        "SPIN WHEEL",
        "SPIN WHEEL", 
        "SPIN WHEEL",
        "SPIN WHEEL", 
        "SPIN WHEEL", 
        "SPIN WHEEL",
        "SPIN WHEEL",
        "SPIN WHEEL",
        "BÁNH XE QUAY" 
    };
    public static List<string> shopJetpack = new List<string>() 
    { 
        "JETPACK", 
        "JETPACK", 
        "JETPACK",
        "JETPACK",
        "JETPACK", 
        "MOCHILA A JATO",
        "JETPACK",
        "ジェットパック",
        "JETPACK", 
        "喷射背包",
        "THIẾT BỊ BAY" 
    };
    public static List<string> shopSneaker = new List<string>() 
    { 
        "SUPER SNEAKERS", 
        "SUPER SNEAKERS",
        "SUPER BASKET", 
        "SUPER TURNSCHUH",
        "SUPER ZAPATILLAS",
        "MOCHILA A JATO",
        "SUPER SNEAKERS", 
        "スーパースニーカー",
        "SUPER SNEAKERS", 
        "超级球鞋", 
        "GIÀY NHẢY CAO" 
    };
    public static List<string> shopCoinMagnet = new List<string>() 
    { 
        "DIAMOND VACUUM", 
        "DIAMOND VACUUM", 
        "ASPIRATEUR DE PIÈCES", 
        "MÜNZEN VACUUM", 
        "ASPIRA DIAMANTES", 
        "DIAMOND VACUUM", 
        "DIAMOND VACUUM",
        "ダイアモンドバキューム", 
        "DIAMOND VACUUM", 
        "钻石吸尘机", 
        "NAM CHÂM" 
    };
    public static List<string> shop2xMultiplier = new List<string>() 
    { 
        "2X MULTIPLIER", 
        "2X MULTIPLIER",
        "MULTIPLICATEUR PAR 2", 
        "2X MULTIPLIKATOR",
        "MULTIPLICADOR 2X", 
        "MULTIPLICADOR 2X",
        "2X MULTIPLIER", 
        "2Xマルチプライヤー",
        "2X MULTIPLIER", 
        "2倍", 
        "NHÂN ĐÔI ĐIỂM" 
    };
    public static List<string> shopHoverbike = new List<string>() 
    { 
        "HOVERBIKE", 
        "HOVERBIKE", 
        "HOVERBIKE", 
        "HOVERBIKE", 
        "HOVERBIKE",
        "HOVERBIKE",
        "HOVERBIKE", 
        "ホバーバイク", 
        "HOVERBIKE", 
        "飞行摩托车",
        "XE MÁY BAY" 
    };
    //Increase time to use XXXXX
    public static List<string> shopDetailUpgrades = new List<string>() 
    { 
        "Increase time to use", 
        "Увеличить время действия", 
        "Augmenter le temps pour utiliser", 
        "Nutzungsdauer erhöhen",
        "Aumentar tiempo de uso", 
        "Aumente o tempo de uso", 
        "زيادة الوقت للاستخدام", 
        "使用時間を 増やす", 
        "사용 시간 증가",
        "增加使用时间", 
        "Tăng thời gian sử dụng" 
    };
    public static List<string> shopDetailHoverboard = new List<string>() 
    { 
        "If you hit an object while riding a hoverboard, your run won't end.", 
        "При столкновении с препятствиями, доска позволит не упасть и продолжить бег.", 
        "Si tu entres en collision avec un obstacle quand tues sur un hoverboard, ta course ne s’arrêtera pas.",  
        "Wenn du mit Hindernissen kollidierst während du auf dem Hoverboard bist, wird dein Lauf nicht beendet.", 
        "Al chocar con obstáculos conduciendo un hoverboard, le ayudará a no caer.", 
        "Se você colidir com obstáculos quando estiver no hoverboard, sua corrida não terminará.",
        "عند الاصطدام اثناء استخدام  Hoverboard،.جولتكَ لن تنتهي",
        "ホバーボードに 乗っている 間、 物体に 衝突するとあなたの ランは 終了しません。", 
        "장애물과 충돌하면 넘어지지 않게됩니다.", 
        "如果您在 骑着悬浮 滑板时碰 到物体， 您的赛跑 将不会结束。", 
        "Khi va chạm với các vật cản, nó giúp bạn không bị ngã." 
    };
    public static List<string> shopDetailChestbox = new List<string>() 
    { 
        "It is a mystery gift box, with ramdom prizes inside, such as, diamonds, keys, hoverboards and more.", 
        "Это загадочная коробочка-подарок, внутри могут быть бриллианты, ключи, доски и многое другое.",
        "C'est une boîte cadeau mystérieuse, à l'intérieur il y a peut être des pièces de monnaie, des clés, des hoverboards et plus encore.",
        "Es ist eine geheimnisvolle Geschenkbox, in der Münzen, Schlüssel, Hoverboards und vieles mehr sein kann.",
        "Es una caja de regalo misteriosa, dentro de ella puede ser diamantes, llaves, HOVERBOARD y más.", 
        "É uma misteriosa caixa de presente, com prêmios surpresa dentro, como, diamantes, chaves, hoverboards e muito mais.", 
        "بل هو مربع هدية غامضة، داخله يمكن أن يكون النقود، والمفاتيح، HOVERBOARD وأكثر من ذلك.", 
        "それは ダイヤモンドや、 キー、 ホバーボードなど ランダムな 賞品が 中に 入っている ミステリーギフトボックスです。", 
        "그것은 신비한 선물 상자이며 동전, 열쇠, HOVERBOARD 이상이 될 수 있습니다.", 
        "这是一个 神秘的礼盒， 里面有随 机的奖品， 如钻石， 钥匙， 悬浮滑板 等等。", 
        "Nó là hộp quà bí mật, bên trong nó có thể là xu, chìa khóa, ván bay và nhiều thứ khác." 
    };
    public static List<string> shopDetailHeadstart = new List<string>() 
    { 
        "Lets you use HOVERBIKE at any time.", 
        "Позволяет использовать летоцыкл в любое время.", 
        "Te permet d'utiliser l’HOVERBIKE à tout moment.", 
        "Ermöglicht Ihnen, das HOVERBIKE jederzeit zu nutzen.", 
        "Permite utilizar HOVERBIKE en cualquier momento.", 
        "Permite usar a HOVERBIKE a qualquer momento.", 
        "يتيح لك استخدام HOVERBIKE في أي وقت.",
        "ホバーバイクをいつでも 使いましょう！", 
        "언제든지 HOVERBIKE 를 사용할 수 있습니다.", 
        "让您随时 使用 飞行摩托车。", 
        "Nó cho phép bạn sử dụng Xe Máy Bay bất cứ khi nào bạn muốn." 
    };
    public static List<string> shopDetailScoreBooster = new List<string>() 
    { 
        "Boost your score while running.", 
        "Приумнож свой счет на бегу.", 
        "Augmenteton score pendant la course.", 
        "Steigere deine Punktzahl während du läufst.", 
        "Aumente su puntuación en la carrera.", 
        "Aumente sua pontuação em fuga.",
        "تعزيز درجاتك على المدى.", 
        "ランニングしている 間に スコアを 上げましょう。",
        "실행에 점수를 향상.", 
        "在赛跑时 提高 您的分数。", 
        "Tăng cường điểm số trong khi chạy." 
    };
    public static List<string> shopDetailWheelSpin = new List<string>() 
    { 
        "Get a chance to win diamonds, keys, hoverboards and more.", 
        "Получи шанс выиграть бриллианты, ключи, доски и многое другое.",
        "Get a chance to win diamonds, keys, hoverboards and more.",
        "Get a chance to win diamonds, keys, hoverboards and more.",
        "Get a chance to win diamonds, keys, hoverboards and more.", 
        "Get a chance to win diamonds, keys, hoverboards and more.", 
        "Get a chance to win diamonds, keys, hoverboards and more.", 
        "Get a chance to win diamonds, keys, hoverboards and more.", 
        "Get a chance to win diamonds, keys, hoverboards and more.", 
        "Get a chance to win diamonds, keys, hoverboards and more.", 
        "Bạn sẽ có cơ hội nhận được kim cương, chìa khóa, ván bay và nhiều thứ khác." 
    };
    //IN OTHER PAGE
    public static List<string> otherNewHighScore = new List<string>() 
    { 
        "NEW HIGH SCORE", 
        "НОВЫЙ РЕКОРД", 
        "NOUVEAU SCORE ÉLEVÉ",
        "NEUEHIGH SCORE", 
        "NUEVA PUNTUACIÓN ALTA", 
        "NOVA PONTUAÇÃO ALTA", 
        "درجة عالية جديدة", 
        "新 ハイスコア",
        "새로운 최고 점수", 
        "新高分", 
        "ĐIỂM KỶ LỤC MỚI" 
    };
    public static List<string> otherTapContinue = new List<string>() 
    { 
        "Tap to continue", 
        "Нажми, чтобы продолжить", 
        "Appuie pour continuer", 
        "Tippen um fortzufahren", 
        "Toque para continuar",
        "Toque para continuar", 
        "إضغط للإستمرار", 
        "タップして 続行する", 
        "계속하려면 탭하세요",
        "点击继续", 
        "Chạm để tiếp tục" 
    };
    public static List<string> otherTapOpen = new List<string>() 
    { 
        "Tap to open!", 
        "Нажми, чтобы открыть!", 
        "Appuie pour ouvrir!", 
        "Tippen zum öffnen!", 
        "¡Toque para abrir!", 
        "Toque para abrir!", 
        "اضغط للفتح!", 
        "タップして 開く！",
        "탭하여여십시오!",
        "点击打开！", 
        "Chạm để mở hộp!" 
    };
    public static List<string> otherTapSpin = new List<string>() 
    { 
        "Touch to Spin\n(Press longer to spin faster)", 
        "Нажми чтобы крутить\n(Жми дольше чтобы вращать быстрее)", 
        "Touch to Spin\n(Press longer to spin faster)", 
        "Touch to Spin\n(Press longer to spin faster)", 
        "Touch to Spin\n(Press longer to spin faster)", 
        "Touch to Spin\n(Press longer to spin faster)", 
        "Touch to Spin\n(Press longer to spin faster)", 
        "Touch to Spin\n(Press longer to spin faster)",
        "Touch to Spin\n(Press longer to spin faster)",
        "Touch to Spin\n(Press longer to spin faster)", 
        "Chạm để Quay\n(Giữ lâu hơn để quay lâu hơn)" 
    };
    public static List<string> otherTitleItemCard = new List<string>() 
    { 
        "SCRATCH CARD", 
        "СКРЕТЧ-КАРТА", 
        "SCRATCH CARD", 
        "SCRATCH CARD", 
        "SCRATCH CARD", 
        "SCRATCH CARD", 
        "SCRATCH CARD", 
        "SCRATCH CARD",
        "SCRATCH CARD",
        "SCRATCH CARD", 
        "THẺ CÀO" 
    };
    public static List<string> otherNoteItemCard = new List<string>() 
    { 
        "Scratch to see your reward!", 
        "Сотри, чтобы увидеть свою награду!", 
        "Scratch to see your reward!", 
        "Scratch to see your reward!", 
        "Scratch to see your reward!", 
        "Scratch to see your reward!", 
        "Scratch to see your reward!", 
        "Scratch to see your reward!",
        "Scratch to see your reward!",
        "Scratch to see your reward!", 
        "Cào thẻ để nhìn thấy phần thưởng của bạn!" 
    };
    public static List<string> otherTitleCard = new List<string>() 
    { 
        "SCRATCH CARD BONUS", 
        "БОНУС СКРЕТЧ-КАРТА", 
        "SCRATCH CARD BONUS", 
        "SCRATCH CARD BONUS", 
        "SCRATCH CARD BONUS", 
        "SCRATCH CARD BONUS", 
        "SCRATCH CARD BONUS", 
        "SCRATCH CARD BONUS",
        "SCRATCH CARD BONUS",
        "SCRATCH CARD BONUS", 
        "THẺ CÀO THƯỞNG" 
    };
    public static List<string> otherProgressCard = new List<string>() 
    { 
        "Scratch here", 
        "Scratch here", 
        "Scratch here", 
        "Scratch here", 
        "Scratch here", 
        "Scratch here", 
        "Scratch here", 
        "Scratch here",
        "Scratch here",
        "Scratch here", 
        "Cào thẻ ở đây" 
    };
    public static List<string> otherDetailsCard = new List<string>() 
    { 
        "Good luck!", 
        "Удачи!", 
        "Bonne chance!", 
        "Viel Glück!", 
        "¡Buena suerte!", 
        "Boa sorte!", 
        "بالتوفيق!", 
        "幸運！",
        "행운을 빕니다!",
        "祝你好運!", 
        "Chúc may mắn!" 
    };
    public static List<string> otherQuickScratch = new List<string>() 
    { 
        "QUICK SCRATCH", 
        "QUICK SCRATCH", 
        "QUICK SCRATCH", 
        "QUICK SCRATCH", 
        "QUICK SCRATCH", 
        "QUICK SCRATCH", 
        "QUICK SCRATCH", 
        "QUICK SCRATCH",
        "QUICK SCRATCH",
        "QUICK SCRATCH", 
        "CÀO THẺ NHANH" 
    };
    public static List<List<string>> otherNameItemBonus = new List<List<string>>() { 
        new List<string>() 
        {
            "DIAMONDS", 
            "БРИЛЛИАНТОВ", 
            "PIÈCES", 
            "MÜNZENPAKET", 
            "DIAMANTES",
            "DIAMANTES", 
            "حزمة عملة", 
            "ダイアモンド",
            "코인 패키지", 
            "钻石",
            "KIM CƯƠNG" 
        }, 
        new List<string>() 
        {
            "KEY", 
            "КЛЮЧЕЙ", 
            "CLÉ", 
            "SCHLÜSSELPAKET", 
            "LLAVE", 
            "CHAVE", 
            "حزمة مفتاح", 
            "キー", 
            "키 패키지",
            "钥匙",
            "CHÌA KHÓA" 
        },
        new List<string>() 
        {
            "HOVERBOARD", 
            "ДОСКА",
            "HOVERBOARD", 
            "HOVERBOARD", 
            "HOVERBOARD",
            "HOVERBOARD", 
            "HOVERBOARD",
            "ホバーボード", 
            "HOVERBOARD", 
            "悬浮滑板",
            "VÁN BAY" 
        },
        new List<string>() 
        {
            "HEADSTART", 
            "HEADSTART", 
            "AVANCE", 
            "VORSPRUNG", 
            "COMIENZAPRIMERO",
            "COMEÇAR NA FRENTE",
            "HEADSTART", 
            "ヘッドスタート",
            "HEADSTART", 
            "开启器", 
            "GỌI XE BAY"
        },
        new List<string>() 
        {
            "SCOREBOOSTER", 
            "УМНОЖИТЕЛЬ ОЧКОВ",
            "BOOSTEUR DE SCORE", 
            "SCOREBOOSTER",
            "CONSIGUEPUNTOS",
            "IMPULSIONAR PONTUAÇÃO",
            "SCOREBOOSTER",
            "スコアブースター", 
            "SCOREBOOSTER", 
            "得分助推器",
            "ĐIỂM CỘNG" 
        },
        new List<string>() 
        {
            "WHEEL SPIN", 
            "WHEEL SPIN",
            "WHEEL SPIN", 
            "WHEEL SPIN",
            "WHEEL SPIN",
            "WHEEL SPIN",
            "WHEEL SPIN",
            "WHEEL SPIN", 
            "WHEEL SPIN", 
            "WHEEL SPIN",
            "WHEEL SPIN" 
        } 
    };
    public static List<List<string>> otherInfoItemBonus = new List<List<string>>() { 
        new List<string>() 
        {
            "You can use it to shop for items and upgrades.", 
            "Можно использовать для покупок предметов и апгрейдов.",
            "Tupeux l'utiliser pour acheter des articles et des augmentations.", 
            "Du kannst es verwenden, um Gegenstände und Upgrades zu Kaufen.",
            "Puede utilizarlo para comprar artículos y mejoras.", 
            "Você pode usá-lo para comprar itens e atualizações.",
            "يمكنك استخدامه لشراء سلع وترقية العناصر.", 
            "あなたはそれを 使って アイテムを 購入し、 アップグレードすることができます。",
            "당신이 항목을 구입하고 업그레이드하는 데 사용할 수 있습니다.", 
            "您可以 使用它来 购买物品 及升级。",  
            "Bạn có thể sử dụng nó để mua và nâng cấp các vật phẩm." 
        }, 
        new List<string>() 
        {
            "Helps you revive when you crash.", 
            "Позволит продолжить игру если произошло столкновение.", 
            "T’aide à repartir lorsque tu t’écrases.", 
            "Hilft dir dich wiederzubeleben wenn du Abstürzt.", 
            "Le ayuda a revivir cuando se choca.", 
            "Ajuda você a reviver quando você bater.", 
            "يساعدك على الإحياء عندما تصطدم.", 
            "あなたが クラッシュしたときに 復活させる 手伝いをする", 
            "당신이 충돌 할 때 회복하는 데 도움이됩니다.", 
            "帮助您 在撞伤 后恢复 活力。",  
            "Giúp bạn tiếp tục chạy khi bạn ngã." 
        },
        new List<string>() 
        {
            "Double-click to use when you are running.", 
            "Нажми дважды, чтобы использовать, на бегу.", 
            "Double-cliques pour l’utiliser lorsque tucours.",
            "Doppelklick um während des Laufs zu verwenden.",
            "Haga doble clic para utilizar durante la carrera.",
            "Clique duas vezes para usar quando você estiver correndo.",
            "انقر نقرا مزدوجا لاستخدام عند الركض.",
            "ダブルクリックして ランニング 中に 使う。",
            "당신이 실행할 때 사용할 두 번 클릭합니다.", 
            "在赛跑 时双击 以使用。", 
            "Chạm 2 lần để sử dụng khi bạn đang chạy." 
        },
        new List<string>() 
        {
            "Lets you use HOVERBIKE at any time.", 
            "Позволяет использовать ЛЕТОЦИКЛ в любое время.", 
            "Te permet d'utiliser l’HOVERBIKE à tout moment.", 
            "Kässt Sie das HOVERBIKE jederzeit zu benutzen.",
            "Permite utilizar HOVERBIKE en cualquier momento.",
            "Permite usar a HOVERBIKE a qualquer momento.",
            "يتيح لك استخدام HOVERBIKE في أي وقت.", 
            "ホバーバイクをいつでも 使いましょう。", 
            "언제든지 HOVERBIKE 를 사용할 수 있습니다.",
            "让您随 时使用 飞行摩托车。",
            "Nó cho phép bạn sử dụng Xe Máy Bay bất cứ khi nào bạn muốn."
        },
        new List<string>() 
        {
            "Boost your score on the go.", 
            "Приумнож свой счет на бегу.", 
            "Augmenteton score sur la route.", 
            "Steigern sie ihre Punktzahl unterwegs.",
            "Aumente su puntuación en el camino.",
            "Aumente sua pontuação em movimento.",
            "تعزيز نقاطكَ",
            "あなたの スコアを 上げましょう。", 
            "이동 중에도 점수를 높일 수 있습니다.",
            "在路途 中提高 您的分数。", 
            "Tăng cường điểm số trong khi chạy." 
        },
        new List<string>() 
        {
            "It gives you the opportunity to spin the prize wheel.", 
            "Получи шанс покрутить колесо удачи.", 
            "It gives you the opportunity to spin the prize wheel.", 
            "It gives you the opportunity to spin the prize wheel.",
            "It gives you the opportunity to spin the prize wheel.",
            "It gives you the opportunity to spin the prize wheel.",
            "It gives you the opportunity to spin the prize wheel.",
            "It gives you the opportunity to spin the prize wheel.", 
            "It gives you the opportunity to spin the prize wheel.",
            "It gives you the opportunity to spin the prize wheel.", 
            "Nó cho bạn cơ hội có thể quay bánh xe may mắn." 
        }
    };

    //IN NOTIFICATIONS
    public static List<string> notifiTitle = new List<string>() 
    { 
        gameName, 
        gameName, 
        gameName,
        gameName, 
        gameName, 
        gameName,
        gameName, 
        gameName, 
        gameName, 
        gameName, 
        gameName 
    };
    public static List<string> notifiContent = new List<string>() 
    { 
        "You are the best! Hurry back and set a new record!", 
        "Ты лучший! Возвращайся поскорее и докажи это всем!", 
        "Tu es le meilleur! Dépêche-toi et établis un nouveau record !", 
        "Du kannst der beste sein! Beeilen Sie sich und stellen Sie eine neue High Score auf!", 
        "¡Eres el mejor! ¡Date prisa y bate un Nuevo récord!", 
        "Você é o melhor! Volte e marque um novo record!", 
        "أنت رائع! أسرع واصنع رقم قياسياً جديداً!", 
        "あなたが 最高です！ 急いで 戻って、 新記録を 記録しましょう！", 
        "당신은 최고가 될 수 있습니다! 다시 서둘러 테스트에서 실력을 넣어!", 
        "你是最好的！ 快点回来并 创建新纪录！", 
        "Bạn có thể là người chơi tốt nhất! Hãy quay lại và trải nghiệm!" 
    };
    public static List<string> notifiPermission = new List<string>() 
    { 
        "Stable internet connection is required for online mode. Dear player, prior to the game's launching, it will request several permissions, including access to Camera, Microphone, Contacts and Phone Calls on your device.  These permissions are only required for the application to function seamlessly. We will never abuse these permissions in any way, these permissions are requested exceptionally for providing app's smooth funсtionality and quality play experience.", 
        "Для онлайн-режима требуется стабильное подключение к Интернету. До начала игры, приложение попросит у вас несколько разрешений, включая доступ к Камере, Микрофону, Контактам и Телефонным звонкам на вашем устройстве. Эти разрешения необходимы только для бесперебойной работы приложения. Мы никогда не будем злоупотреблять этими разрешениями, эти разрешения запрашиваются исключительно для обеспечения функциональности приложения.", 
        "Une connexion Internet stable est requise pour le mode en ligne. Cher joueur, avant le lancement du jeu, il demandera plusieurs autorisations, y compris l'accès à la caméra, au microphone, aux contacts et aux appels téléphoniques sur votre appareil. Ces autorisations sont uniquement requises pour que l'application fonctionne de manière transparente. Nous n'abuserons jamais de ces permissions de quelque manière que ce soit, ces permissions sont exceptionnellement demandées pour fournir une fonctionnalité fluide et une expérience de jeu de qualité.", 
        "Für den Online-Modus ist eine stabile Internetverbindung erforderlich. Sehr geehrter Spieler, vor dem Start des Spiels werden mehrere Berechtigungen benötigt, einschließlich Zugriff auf Kamera, Mikrofon, Kontakte und Telefonanrufe auf Ihrem Gerät. Diese Berechtigungen sind nur erforderlich, damit die Anwendung reibungslos funktioniert. Wir werden diese Berechtigungen in keiner Weise missbrauchen. Diese Berechtigungen werden ausnahmsweise benötigt, um die reibungslose Funktionalität und das Qualitätserlebnis der App zu gewährleisten.", 
        "Se requiere una conexión a Internet estable para el modo en línea. Estimado jugador, antes del lanzamiento del juego, se le solicitarán varios permisos, incluido el acceso a la Cámara, Micrófono, Contactos y Llamadas telefónicas en su dispositivo. Estos permisos solo son necesarios para que la aplicación funcione sin problemas. Nunca abusaremos de estos permisos de ninguna manera, estos permisos se solicitan excepcionalmente para proporcionar una experiencia de juego divertida y de calidad sin problemas.", 
        "É necessária uma ligação à Internet estável para o modo online. Caro jogador, antes do lançamento do jogo, solicitará várias permissões, incluindo o acesso a Câmera, Microfone, Contatos e Chamadas Telefônicas no seu dispositivo. Essas permissões são necessárias somente para que o aplicativo funcione de forma perfeita. Nós nunca abusaremos dessas permissões de forma alguma, essas permissões são solicitadas excepcionalmente para fornecer a funcionalidade suave da aplicação e a experiência de reprodução de qualidade.", 
        "مطلوب اتصال إنترنت مستقرة لوضع على شبكة الإنترنتمطلوب اتصال إنترنت مستقرة لوضع على شبكة الإنترنت.عزيزي لاعب، قبل إطلاق اللعبة، وسوف يطلب عدة أذونات، بما في ذلك الوصول إلى الكاميرا والميكروفون وجهات الاتصال والمكالمات الهاتفية على جهازك. مطلوبة هذه الأذونات فقط لتطبيق لتعمل بسلاسة.ونحن لن إساءة استخدام هذه الأذونات بأي شكل من الأشكال، وهذه الأذونات مطلوبة بشكل استثنائي لتوفير فونتيوناليتي السلس التطبيق وجودة اللعب الخبرة.", 
        "Stable internet connection is required for online mode. Dear player, prior to the game's launching, it will request several permissions, including access to Camera, Microphone, Contacts and Phone Calls on your device.  These permissions are only required for the application to function seamlessly. We will never abuse these permissions in any way, these permissions are requested exceptionally for providing app's smooth funсtionality and quality play experience.", 
        "Stable internet connection is required for online mode. Dear player, prior to the game's launching, it will request several permissions, including access to Camera, Microphone, Contacts and Phone Calls on your device.  These permissions are only required for the application to function seamlessly. We will never abuse these permissions in any way, these permissions are requested exceptionally for providing app's smooth funсtionality and quality play experience.", 
        "在线模 式需要 稳定的 网络连接。 亲爱的玩家， 在游戏启 动之前， 它会要求 多个权限， 包括访问 设备上的 相机， 麦克风， 联系人 和电话。 只有应 用程序 能够无 缝地运 行这些 权限。 我们绝不 会以任何 方式滥 用这些 权限，这些权限要求非常高， 以提供应 用程序 的流畅 功能和 高质量 的播放 体验。", 
        "Xin chào bạn. Ổn định kết nối internet là cần thiết cho chế độ trực tuyến. trước khi phát hành trò chơi, chúng tôi sẽ yêu cầu một số quyền, bao gồm quyền truy cập vào Camera, Micrô, Số liên lạc và Cuộc gọi điện thoại trên thiết bị của bạn. Các quyền này chỉ được yêu cầu cho ứng dụng hoạt động được hết tất cả các chức năng. Chúng tôi không thể lạm dụng các quyền này theo bất kỳ hình thức nào. Xin vui lòng đồng ý cấp quyền để trò chơi đạt hiệu quả tốt nhất. Xin cảm ơn!" 
    };
    public static List<string> notifiButNext = new List<string>() 
    { 
        "NEXT", 
        "NEXT", 
        "NEXT", 
        "NEXT", 
        "NEXT", 
        "NEXT", 
        "NEXT", 
        "NEXT", 
        "NEXT", 
        "NEXT", 
        "TIẾP" 
    };
}
