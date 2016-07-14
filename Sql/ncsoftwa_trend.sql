/*
SQLyog Ultimate v11.11 (64 bit)
MySQL - 5.5.0-m2-community : Database - ncsoftwa_trend
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`ncsoftwa_trend` /*!40100 DEFAULT CHARACTER SET latin1 */;

/*Table structure for table `pages_users` */

DROP TABLE IF EXISTS `pages_users`;

CREATE TABLE `pages_users` (
  `Page_id_PG` bigint(20) NOT NULL,
  `User_id_PG` bigint(20) DEFAULT NULL,
  `Name_PG` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`Page_id_PG`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `pages_users` */

LOCK TABLES `pages_users` WRITE;

UNLOCK TABLES;

/*Table structure for table `producto_top` */

DROP TABLE IF EXISTS `producto_top`;

CREATE TABLE `producto_top` (
  `valor` int(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `producto_top` */

LOCK TABLES `producto_top` WRITE;

insert  into `producto_top`(`valor`) values (2);

UNLOCK TABLES;

/*Table structure for table `productos` */

DROP TABLE IF EXISTS `productos`;

CREATE TABLE `productos` (
  `Producto_id_PRD` tinyint(2) NOT NULL AUTO_INCREMENT,
  `Descripcion_PRD` varchar(25) CHARACTER SET utf8 DEFAULT NULL,
  `Precio_PRD` float DEFAULT NULL,
  `Imagen_PRD` longblob,
  `Promo_activa_PRD` tinyint(1) DEFAULT '0',
  `Url` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`Producto_id_PRD`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=latin1;

/*Data for the table `productos` */

LOCK TABLES `productos` WRITE;

insert  into `productos`(`Producto_id_PRD`,`Descripcion_PRD`,`Precio_PRD`,`Imagen_PRD`,`Promo_activa_PRD`,`Url`) values (1,'Gestion FREE',0,'',0,NULL),(2,'Gestion PRO',150,'ÿØÿà\0JFIF\0\0H\0H\0\0ÿÛ\0C\0		\n\n\n\n          ÿÛ\0C\r\r\Z\Z                                                 ÿÀ\0\0È\0ÿÄ\0\0\0\0\0\0\0\0\0\0\0\0\0ÿÄ\07\0\0\0\0\0\0!1A\"Qa2Bq#Rr$‘%34‚¡ðÿÄ\0\0\0\0\0\0\0\0\0\0\0\0\0ÿÄ\0:\0\0\0\0\0\0!1AQaq‘\"#2¡ðRÁÑ3Br±á$¢ÒâñÿÚ\0\0\0?\0ú¤\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0K¨úáÚSê×øÌÆFd«Œ©ìé]îïÅ;vO*¨Ÿr¶«?‡:ÌövøûfYæž\\TŽkO¹ì\'\\GãÓRÓ“ Ÿ?ðo„‹áÿ\0±,l’oÿ\0Ûøz·æý6tcWÁæüž\râŸÇÏ;üy{~û?!êu¼¯KòùúŒJÜS]ºêœ’;Ûº5ûüª‹ïû{ÕÍ°Í£¥¡›p\náâ8ð[ïáÉÖ\'Ö¿&æ‘êÎ“¹‰ÅA”ÍÖLåŠñ-¦/ÈßYÍîŠí’6®þÛ›aÖRb7˜æAÄý›ÔÓ.IÇŠÞZvóéþì\Zçªpiýc…Â6ÅxëJõvjY7WÃÈ¬O¢rGo¿s\Z_%â¿Tœ#ÙéÔérfÚÓh¹·œùý¬ÞµÒ˜:ðXÊäá«¦ó¯ÉU\\ö¯êk»•;ùØ³|ô§yqtœ+S¨´Æ:M¦½ýß>ÌØS§³8é28ËñZ§þ´¬_ÉÅ7^m_™½»÷C4Ë[Fñ=êxv|ðòVkiíïø!ßÕžœ1bEÏVþwäÙ\\¾û|Êˆ¼òØ‹í˜¿ŠãÙ½|ïøVéûùü“ùîŒþ)rä0ã¸£ÒÓžßMÈïËÅÞ—¶ÞI­’±Ïg7.\\žk3Mº©}/ÖÒj	¯®C9RÕÉ$sêb+\"7Ð®‹Ûæsù¿uï·î¥]&~}÷˜ßÑßöƒ„Æš+ÉŠõ¬G[Ïœýf!Ð‹¯.ç½5×7²X­AÔW\"e|fBX;Ñ±±nJ›\'•÷)iuh´ÛÊ^£pŠbÉŠ˜+;äÇ·YÞSX¾§h,¥öcèæ –Ü«Â(—“9»Â5ªôj*¯²\"÷%®¯§hž®~£Ùýn\Zsß¢±ûòZ:;¨p¹¦Îì]¶[JÏô§áúŸ¥wØÒ™+nÝVµZ,Ø6ñ+5æãàÅÕšk!Ž±“§‘‚\\}G+lÛå´LV¢9y9Û\'dT1\\Õ˜Þ\'¤7ÍÃu²F;RböírÐÃõ#Cf/¦?˜‚{ŽìÈ~f+Õ=™Í\ZŽ_ØÒš¬v¢z¬êx³9òc´W×úíÙ“9Ô\r‚´ê™l¬U-5¨õ…Ü•ü]ávj(É©¥\'i–ºN«ÔW›&ÕõxÉõCââ«-ìÄ6ìMž²|Îs¢zn×ñj+‘«ìª‚Ú¬uï=Ûiø³4Ú)Žg–vŸ£ÖKRP½¤.eð™ŠÐÄØ×ÓÊ/ób‰É¶üÛßÆýÑP[,M9«1ñc‚øõUÅ›¦wü½¦~\r{\Z¾žDWËä²•lØ’ª:J¾”V§á»x7ÎÎ_¢vCš+y˜íõINlúÉÅŽ–­bÝc¼Ö7óø5z]©¤Íá÷sµ³d^Vc¬ÖÆ5+xñËýÊž|\Zi2óW¬ÄÊht§Íµ1[?-úïúÌ|›6º©ÓÊª©>r»\\×¬Nbrs‘íó»ZŠ©ûø6^(óCÙÝuûb·mÖ:\n9\Zq]£;,Ô9E<NG5ÉöTû–+h˜Þ;9Y°ß¦—‰­£ÊTŽ¯êA€Æâ	eµl_¾Ê¯‘ñ¶Tâö»ÙÛû”õ¹mHŽ_9zf8~\rNLž4sV˜æÝöGêDêöœÃYÎÄ4²qPo­=9)6tmüÛ9«¿dû¡¦_•ææ‰ÛÜµ þËÕeŒ>\rñÍúDóïÕ§Ÿê©ÉYÑ1éûLÅ&§‰îŸÔ‰–8=8ÿ\0RwD]þ›šdÔÞÜœ½9“è¸.›u3ž³“ìóm3]û²êÛ][Ò8i3òghåªSV-ª’TlµïF&ÊÕÝ{»ê†Ù§>:ósDÄ{špÜ|/[–0F+ãµ»O6þ[¤µOR²£§©iº­›PêˆcžœSÿ\0Ó‚)Y$ÛmöÝÙWÛeß.ªv¬Wó]S‡p\ZMó_Qm°iæbvïi‰ÛhýùÃW)K­8<k³\rÏÕÍ¾³Vkx‡SŽ&«ÝÉ‘£^õDñ¾Æ·®zG74[Ý²m>^¨ÉáxVÅÍÒ/Ï3õ‰éªé£uM=Q§jfª5ce„_Rî±ÈÕâö*ößeNËî…¼c%y¡Àâœ>ú<öÃn»yúÇ”¦‰\\ð\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0¯­|¨e´f£™ªìf##þ¹È›ðI‘Ý¾‰\ní÷9Úî“KyD½Ÿ²Ÿ‰‹S§ñ2cû¿.oêéOÊãŽ\\›­D˜äg«ñ|Ûépþ®~6/óÆÛù<”i²NO–y÷Ûmºïðp¬+d·Ó®¤ê1c¡˜µ4´‘SmØ’+•SíüÍ¿ÁÇ§\\Y-å2ú>ªbšý÷ÅX‹}?á»o¤[øwŽÊCª°2VØÙ¾¯Æ¬¨Žù¿7.[·û{x7šSì¿¾êøõ:©ã¼»Ûni¼¹6ýÏÅæücPt¡ùZû6j·âýF¢ºM¢oS+·ÔÅ£{bßÑ¶òà×Å\'îÖÝ=Ýg³òä\ZŽ×\\s1c£ÄÉ~µh“e&X›G\Zÿ\0¦l_«º¯ûýÄÅ§Q;rï·Mÿ\0‘Šø)ÁñÎIËµ§›ÃÛ}÷ŸÍ¿—ü74î-ŽÖ:¢{·p±Y±Š›ãðØ‡Nœ_ÅªÉV)\ZˆŸ›õxîoÅí¼×òö„\Zí^,º\\JæšÆXå¾N_¦ñ?ËËÜÑÒ8,;¿¹[o§íM¹Ÿ;˜Šþp¹R5åçåâ›\ZaÇ_³LüV8–³,qÌuæžXšFÞéïõDjä&Ó/­½wT‘²dÿ\0é˜æ64±Ã¿EÛößØ‹&ü˜½=ý—´QJê5ÖûÜÑüsí×~]üÖ,ÞÕ­ÕúböbÎ™Ä]‚Ó¢P[PÍaˆæ£¡ÙÌr96ùQ;yÛÜŸ&;óÖmÉ¿–î^“]¥û.zbNZMg~nIŠÏ^½úzü°ë>zùË‘ÀRéî§þ5EùgÔ.†½FJø9OÃ“yHÏ\rDb¯¹Â­«­Íý÷Õ³àÏ“]ƒÁ´RcO¼ÎÑ=7ôŸ‹\'PY©á“K&_‰ÃFË°¥\n´U]m\ZÕM÷r|¾›{x÷ØÎ§Ÿîï¯_.í8,éæ3øWË–y\'šmù®ÿ\0ÉôIÜ|±óî«ÍËÓÍc¬ªÄŠÊú’—Äãöö±+¸òOdâçÌ¿á.lž\rïÅ?WÓøv’8¦—Miï‚û[ý1ýv¯êk<½?Ñ9DôÛnä3åynå;*6^ø·åEÛúPÆ|sM=cÖzœ+Y]OÍ~ü´˜§Êb:oóú¶µ¾˜Õ“a1¯ÉO¤°µkË±y\ZknµväÆÆþN+ù¼}Íóâ¿,oá×Òz¡á<CM\\×Œq«Ëi‰æ­¹\'ã¼o|¿DÚcê^ü@=·áŽÇ¥ˆlœ\\Ôs9ìÖ*ìï³Ô—–\'S×ø\\ÿ\0\ZØøÜ™ómòïüšùý?}½MÈd4m¼eÜÄu#Žîž¿\Zÿ\0.&ÇÒìÙZŒðæí¿ÑMrcŸgÓ;v”º-m?³©M]rWÞyrV{Îó=|ý|§²:†S7M5æ.+pyrÿ\0Í+C+¦Ó=ÊÞLäç#vX•8··ƒJÞ<+ÆÜ³Ö³iòWˆirNO—ü³1´í¾½ûÏV¶2\Z–õwL©åÑ$ÅcëÅ/xkŒ•¶û¶?Ýv5¬Dß[·/ê—QkSK­¶.™<ißnü½?öýVKUéÒüBâÙˆka[8ùW3;5¿’Uj½ÝU±¯û)bb#U¾\\œw¾NyË×—$roñ¯oû¿V—H0X{˜­ebÝ8¬K-ë5ÜéXŽ_IËŠoá7væš,u˜¾þ«Ók2Ó&š+iˆŠVzz§ÿ\0ŽrôâUUFÙ\ZŸDå¿oò¤Ü7ü/›™í¬×ÏújÒüA2I1:y‘ÉéHü´Md¨›ñUc¶vßcN%Ú¿êXö.b2æ™ëÿ\0¼$r-ÔYzÿ\0œÖ—nc^©ëÕŽ`æˆ»ì®ný¿t$¶’ÖékÌÂ®hp`·>5+“Êw™Ù^ê^ëNŸàñóK‚4–½y«/bkx\"+\\»÷íäƒUñ1Ö::œY?dÕæ¼Eæv™‰í=Ñz÷M\\ÓÙÜLº¯-‘Ô\ZÌÉ†Í;ÓÑ›ô¬ˆÞÎO~È‹¶éûÇ¨Å4´sÌÛ\Zç××U‡$i±ãÃ«¬tÚ#¬{½?øžÖ3RÁuwHgçáZNÇÃe6ôbvÒ£’|­nÓ·¿¿blÓÏK—mœÞ[ê8^£o9¢üósùñŸ›¤êö/„³•¿+RÕÿ\02¦Ï]·kõWxD/äÉ®óÙä´Z<šŒÑŽ‘<Ó?OÉLè6Ý.Wu†«~2ylÂÕóé»fµÏ\rÓ÷*ðêÌbø½¶yë“_<¿å¬DürèÅç”\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0‚ý\nY\nrÒ»,Ô¼f†Dä×\'ÝÅ«Od˜s_¢ô™­£´ÂŽé÷=¾\ZÂÔçê%³7¡¿öòßÿ\0e?°bù|^‹ûÝ®õ¯6ÛsrÆëeÍ9†·~õšÌT‘zZ/åµ#OÒÞ;mþ6ÅY¯/“‰‹]–™¼xŸÄ‰ßyëÕU¯ÑžAf[JWÅ’FÔ’y_½?S˜å]÷Û¿²•ãA‹ÑÚ¿µºûVcš7Ÿ>Xßê›ÕzNjƒ\\œOIh*­IàzÄörÛtEo·Ê„¹´õÉßÉÏáÜg>›Ã˜Úýâcx–ÿ\0M4žy)ºýyÝ6*÷£•ñØF³Â:D_›ü˜É¥¥û÷„š.=©ÓsrLrÞwšÌD×éäË§zy¥4ý[pcª«]}ªË¶${¤šDvû¢½Ëºyö3MJvói®ãzM«9-ù;DFÑ&zZ\'ORÓiŠð9¸yY$o…dz»ŒÊªÿ\0W—}þ¦k‚±NO$yx¶|šˆÔZ6ë´yvèÇk@éKzj\r7j’M‰¬ˆ•ãsÍ›xsdßš/;˜=&œ»tmŒêi¨Em¶Kw÷ü»40(Ñ˜L”y:õå±zãZkR¾oI²pG|©··nÞÆ˜ôxé;ù¬ë}£Õê1Î;LE\'¼V\"7ø®§	T^—èÇaïaÝI]G!cã,5dz»×þ¶;}Ú¿±[ì˜ùf»t—kûÁ«ñk—›ïÒ¼±Ò;zOª6>ˆôý¨Þu§šhÜÇEbK3,Œôÿ\0+Z¨äÙ©¿ƒO°býÊÝ½­×Oi¬DùEcn«éqæ•ÍSÓí+ª,Õ±š©ñÓEHUævr¢ìî*œ“t÷ Ë¦¦OÍäêðþ5©ÑÖÕÃm¢Ýú%òØ|f_6;%]–iNœe…þéãeEOeNèKzE£iì£¦ÕdÁxÉŽyoj–7£\Z…ÚöÛV[QyT†ÌÒKK¾ÿ\0+vóõÜ­]8ý¼þÕkrRkÍÍÞb\"&~kt®º™ú•\"_âïƒá77mévíÃ~>ßBo¼üþn\\ñßgû>ÿ\0…¾û{þ(ÝMÓM\'¨²,ÉÞ‚H²,oŒ­+á‘Z¶wÙ|ùÛsLºZ^wžëz=©ÒÓÃ¤ÄÓÒb&(ôëIQÓ–´õj|1×¿ï>wz’ªûºMù{}L×MH¯.Ý%¦n9ªÉž¹ío¿NÝ:GË³ÎW¦úG+ƒ¥…¹OLk”rK\"\"|²oËÙ7ÜÅô´µb³ÚÓqÝVÖÍK}ëþn\'äÉ¥º}¥ôÄÓÙÆWwÆÙí=ÉÞéfro¾Üœ½“§Ÿs8tÔÇÛ»^#Æµ:¸ŠäŸ»^Ñ´6°:G‚¯v¾6EBWÏiî)$Mœ¿2®Ý¾†ØðÖ›íæ‡YÄój-[dæ‘´tò†M5¦púo˜ÌLK\r6½Ò#ç=y?Ïw*©œX«HÚ;5×ëòêòx™g{}u•ÂêêÇ•‰em)Ûf¿¹›JßòªoäÆL5¿&t<G6–m8çnhÚ~	rUFSJáryŒn^äJûØ•s©HsQªý·Ý¨»/r+á­­žð½§â9°â¾*ÏÜÉù›Ü/;ŠŸ”…\'¥a$ºx]ÑQSº**y6ÉŽ/OdZ=^M>HÉŽv¼5£tìºr-9f¯Åâaj28,9Ò+Q¿—gªóEnû\"¢îˆkàW——¼\'Ž)ž3Î¢¶åÉ>qÓôì®Õè–€†hŸ%Y­E]w‚­›I=û1Wm¾ÊA\Zn®Ok5Ö‰ˆ´Vg¼Åb\'ê½±ŒcQŒDk\Z›5©ÙÙ73»ô0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0?ÿÙ',1,'http://localhost/Trend/trunk/private_html/'),(3,'POS',100,'ÿØÿà\0JFIF\0\0H\0H\0\0ÿÛ\0C\0		\n\n\n\n          ÿÛ\0C\r\r\Z\Z                                                 ÿÀ\0\0È\0ÿÄ\0\0\0\0\0\0\0\0\0\0\0\0\0ÿÄ\0=\0\0\0\0\0\0!\"1A2q#QaBRbs‘±$3457r¡²´ÁðÿÄ\0\0\0\0\0\0\0\0\0\0\0\0\0ÿÄ\08\0\0\0\0\0\0!1AQa\"2q#R‘¡Á$3Bb±áð5r²ÑñÿÚ\0\0\0?\0ýR\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0¹›×¸<VM1(Û9¿«±øø]bf³úÏFöjw÷RšŠÖvë3ìêé86lØü_†˜·ÛšóËûz½aµÖ1Býª2=eÆ#þ:”¬X¬Ä¬E^/û*o·ØÍ5´LÇ“\Z®Ÿë[í¶O–Ñ;Ö~“	š[PÖÔx\n™ª±¾.5\\ÈåÛšqr³¾Ê©ü¦Ø²s×›ÕÑ[KžØm13_OÝ:[Ô¡³YlG›<¾\Z=¨ù8\'\'pj÷vÍM×c~hì­\\WšÍ¢&k^óåVs(À\0Tj=OŽÀW‚[m–imÌÚõ*WoRyd³ºo²wR<¹b×´<?&¦ÓÚ\"±¼Ìôˆy[5UZŠ©ÅWÙ}¿ÃrEPj=q„À]©¶–\'È^G:­:>Ä¯F}Jb*ö!Ëž´§¼ºz›SK^¼±Jw›LV#«&˜ÖšS6ÏÊ§s¦¦äeÊÒÆø¦‰Ë¾Èö=}”bÏ\\¼šñŸI·‰-Úbbb~“Âg8ÄÓCOšg¶(£Et’=Q­j\'ªª¯dA2Úµ›NÑÖeæ­ª¶ë²ÍY™b¼©Ê)¢r=ŽOÍ®nè¦\"wìÎLv¥¹m)e2ÐƒZk\n:SFÜ2XI§eh¡‡7I&ê›rV§ò©|ÑŽ7—O…p»ërøu˜«3¼úBü™Ì\0\0\0\0ö28úÓÁ^Å˜¡±exÖ†Gµ¯‘SÕÕ]Ü¿ch„´Á{DÚ±3ï;vú¤D‰•È³B[¯‚{-‹ŽðÔ‰ÓÌîNFùcfî]·ÝC[Û–7O§ÁâÞ)½k¿§hýåªÅâÆk“Ò‡˜’å^+f³1ó¬±óMÙÍˆœ›É;¦þ¥hÖW}¶¶ÿ\0Gfßg3V±y¾­»O‰]§nûO›tc¹5²¦é¾ËÙt-¸¡€\0ú»STÓ\ZzÞrÜOš½NŸ8âÛšõ$lI·%Dõyl±Ž¼Óä¿Ã4Õç®\ZÌDÛ~þÑ3ý°Ê’ÂÉS²HÔr\'Ý7%…+WiÛÑ©¿Å\r>·,AR®C!\rI~Õêu$š¼r§«UíõÛôE*ýî»ôÞvô‡n>Ïçå‰µ±ÒmÅmx‹L}Pêl\\Ú’ÆcŸó*µÛjV«Œé¹Qgú*÷&Œ±ÍËæçÛA’ºxÏ;xv·/~»ýª¨‰ºöD$Ra§vÚí³Nxì×zª6h\\b«UZíœÝÓ³‘QShžÉ2â¶;rÞ&¶ôžŒÆQ€\0\0\0\0\0\0\0\0Î|$HäÉë[6ß›ž+*¿R@Ïõ	ÿ\0*yö(èûß×™êþÒïôÕ¯÷^f>³ó~½•ú†8âñròÑìéôÕ‡eQ¾‹³•#sÿ\0µÙ‰öØÓ\'÷Ó·äê³¢™ž^-My?®ßÊ‹L`3pø:ÍIWQ^©viíÒ­¼j68÷tŸÛH¯â½Ýî¿ã,vð9¹§xÑÒâ\ZÜ6â¿w¶\ZZ·µki˜ø·˜Ž»ùmìÏ‚]G­ü>ÈÍvå9³t\'ž_‡—§ÐsiòwÃö^õú¿43hçÉŽw˜æéä‹\rãK£ÕãŠÒÑ‹%c¬oÍñÿ\0‹×o$ÜÞ)‘×L\"ËùV\n\ZñFÜ\Z~;ç–>}[&ËöOEÛîo|“9&¿Õôþ¨4š<x´tÍ¶4Ú´DNÛV?æÌ9­E®ëøI‹ÒÚÇgaÈÇU¶ägFi\"çä{›úµv_Ïc[äÉzïÝ¾—C¢·šÒ+|3Žm´uˆºÂæhó:WÄ/I™«Ù:yöÚ†ü¥ê·xÚô’$ôuw£{Ï6<µæbÛ÷P­±k49ï8éŽØyf³XÛ¥§m§×õk–µ{Qe5–;<×ãmOGÌ<{Ö‰ð&Ü¬m·7=väÕö_¶ÐNK^mót£g[‹—\ZþâV-“ÄŸŠwü¾›yO««hÛ¹‹º_g5«e_\n%ÈžÞê7Êª­öå·/Üé`µ¦‘ÍÝâ¸¦,Xõ7®æÇ¿O>ŸíÙÎó×òÓxâÉ1x·eåÁâøü3fŠ±¾ïWÊ¨ŸLÈ»þ…–Ÿ¼tùaêtxq×ƒí’þfËßiöòÚ>Š­QCVé9ŸÔ–çm=MªïÔ¯4¤_ôv1UÍcdM¹=ZÕk¶ö#Ë[ã­­=-yŽË¼?6—WŸž±Í§ÓÒÓ3hù½öôß¬6Ýa“ËA­´.›£zfu^ù²<\\¨³E]­ru6îäwMûîYÍiŒ”¬OÕÄáš|VÑêµ¬tˆŠûM½?xUPL¾©×\ZÉgÏßÇiü;Û^8)L°í+#V½ÈîêÔjÄ®TOUR:ï“%þ)ŠÇ¢îoG£Óm‹óeë½£~›ôý÷Ú=\"\ZõÜîg#ý]Ê_²ëk:Ã©&Î°Å›¤¬™{«ÛÅ_Ûßd ¶KN—yž®¦-&,\\w“+ËË¼ôùgm÷Iíû¯oC›Ó­Ó\Z“³ìâ\'ÅÝÝWU‚¼iÔmfª\"3}·å·îMnjrã¬õ·ñôsq[«ÇÖæ¥f˜»Dtæ™žœÞ¾I”™Ó¾-ã´Ý|µÜ®\'#Aö-Å›â˜’m\"={§\'F‰·§±µy©š+¼ÌLy Íµ\\.ú‹c¦<”¼DrG.ýºmúÿ\0Ï5F[\rŠ¡K\nä3œ¹>œÎMÒ>¢÷~Ëºn‘>äÚ¼³Xˆ¯ÍiÙÍû;ÃñgËkæë‹&ó»y4}c¤íSÖZ#\r&rþb;·>&ôæê³•Ek–F7ùÍ{Ód)çÃ1zWyçÏÙèø_­ôš¬±‹)­6¬Ö6ù·é>»LCìÚ«;ª³Ù˜ìô8ºÉGÌ‡V/YlHŠÕr®í^›)™Ël–·Í´tŽ_êÅxv,Qø’ñ¿‹=vŸ*ÇïÕÒ¼;±¨lhÌdš‰’G™âöÚlÍá\'’W5ŠäíÝXRþšm8ã›æy.9LÕÞ0m8ºm·nÑ¿ó»ŸYñ)¥óÚò•ëR[³à~«#•ÿ\0‰m[m]ü­ê5vOd)N¦qÚñ=}?W¨§Ç¬Ã¥½+¬Å¼IŽ+ç>ý\'÷C±—Õô¯â4e‹¹kVWæz’Þ;yï+¤]›NUü8ÙåErzîi7¼LcÞÝ·»§¦›K’™5u®*×›“_¥:Š}fzôM«Õ¸m!®gºìœXú±³øzÖUÛh¶QÑ¯â*«•cz³eÜÞ2^´¾ûíå¿u|š=.}V–)áÍí3âF?—áÚ{{ÆèY4ÕX,‹Ë®¢ÈÙÎå®Tdôå›zîŠÃy¬k¢«|­W/®ëúm¥¹éZ[šy¦acO÷mF}N/pã¥¶˜‹zùïïÖvXê,ç|r­I27bŽž5n½ÐËÅÐ=ßƒ´—¦ŽN\nïÏrL˜ùõo=#u]³îü\ZoÉI›dåë7ŸÅëç²¼ÔÐKjî\'¨l.)ÆT™°ã š4k8¹Û±Ó+Ÿõý^½½5{Ífý?eŽ ˜œtÍM<xv´o’Ñ=}ùzvíÙÕ´•«öô®ÖAy^±J¼¶]é¼åûî½Î–™¤L÷Ùâ¸–:SS’´ù\"öˆúnÔ´Ÿüa×Ýc?ñ«‡ûûþŸèîq/úV—ë“ÿ\0%~žfs1â¦šÞrôX­=v7ÖÇW—‹$Uj¹Y\"l»Ç³>}Í1ó[-·™Ú³Ùg[8phpEqRrf¤ïiŽ±ïý{µjz—Zgp3j*oÔÎÍ3¤ÆÅN.X–ÆÉ8ô\\ÏI;5Q\\©¾ÿ\0¾õã.K×š9¹¼½¬º\r&Ÿ4`¿ÝüŠm?‹¼Ç}ü¾·R[ÔMu¥1-È[ÃWÉãäŸ#^»¸?“[ÔVwß‹·N;ú¡g,ÚÙ+Ìo\\=<tYòòS,ãÉYž¾Ûý<Ø±:3¦îkì\\×\'ËWÓ•ã»’ãÖY“­]eé¾Eó9¨»z˜¦[RoùzÆíõ:Zªé2Ec³Úkn^‘ÒÛoå-kY`s3x7üKPß·rôUm\\¨ùw¦öYš5dmƒn,XÕÍ]Ûù/í_>;xói™¾Ž·Öb¯û½0Òµ¤Ú±;|_O^o=ú÷w*ì5¿ºgý¨v+Ùó¬ß<ýeËdTxW»0ÇcDºÒÏ,i».ÔIÞˆ«ýY\ZŠ¨Ÿ¯öNwÇ§÷Ç¿ëe¦ã3ZÌÎ-_.Þ´¶ßÌÎë&æóÖüDÏÓÅ[sÙòÙÅW‘ß€–dÛ¦þ+ÛºªnIâZrÚ#òôT&\Zh1_%zøû^|ùc¼(ôue¼6o/Ÿ£ªÝJ_Œ£reloTr;­S²µ8íåöUõõ!Ã;ü6›Eöÿ\0›:<Rž.\\8ð_MÏZ±Ö?Ë?ßÏnÝ•úO#sJxºš•»\\•’C^´¯çZºëâêG§eïÉ}wSL6œz~xïþë\\Kuœgî÷­b±131ü;Lÿ\0E¶Þ­§¨°KQºŠÝ{éj›Ä«_Î¦‡×¤w}“Û÷ÞLsx´mÏ>»©k1éoƒ/7ÝëjõÇáÏÅôŸÍ¼/	_Pgsºï–¢ÈÒƒýñµêÌ±µ²,jôWmÝX=¸zwSZö¿Å1ËÙž|\Zl:_ÁÇiËÚ7é¾ß¿^ê¯™êªº¯Ÿ¨/O“šÜL±IÏD¦øE‡‚ÀÔFï³7WzîªGÍxÇ\\œÓ¾ÿ\0¢ïÝô×ÖåÑF*F8¬í;|q;o¿7>ÍÄ¤SærñwsÓeèÔI_+b©QÜUì}…U’¹;«UWt\'Ôßâ˜‰¶ñ]¡Êàºy®*_%pF+Û¾HÞ×òÚ½ûzôê{?­2úIfYñÒÑ“šêEÄ*2ó™\ZôØøøì»/+øíû\Z[&Kc­ºíç·uœ:-&\rn£òEãoÄù:õÿ\0·t\rÅ_Ó5çÅä¬ejò‘Õ×+¬\"óUéÈªˆ»³}»ûtö‰§IÞ=ÞcŒáËQ1’•Çn+òöïVÂNå€\0\0\0§•ðþ³’çðù+8<½†#-Ë[¦ø§Fú,°Ê×µ\\‰è¥ké¾.jÌÖ]­?\ZšáŒi\\¸«Û}÷¤ÄÄ³a4+MÝ{rY†«2KNGÎôTV¢&ÈÖµ­ß²\"‘šiâ»ùÌù´Õñœ™¦+\\x¾Z×·û¨kø9^3pÔ9/áõ^V1»Ã³×~J‰\'O›\Zåîæ¢ì¤1¢øyy§—ÑÒ¿Ú‹[/8qøþVëÓôßi˜ò•Ö¡Ð52sá­ãîÍ†»GGŽš²FälObF¬VH×\"§ì„Ù4ñm¦\'i¯g?EÆmŠ2VõŒ´ÍóDïÞ\'}÷wŒŸ‡é6kçØ¼½¬Neð²½»0¤R2ÃXˆˆé¢‘®b¹=L[MñsDÌY¶5Ë‡ÁÉŽ¹1o¼Dï»úLNû2æ4,Y1\'“µk§3l:óú}g¹W¢.ÌFmßoOC7ÓóS–fZix¼àÔNlt­w¹zíÛo]Ós\ZRžW?„ÍM4ŒŸéÝ^6mÁÿ\0Ö±Ü÷E^Ü{lo|1kE¿*¾—ˆÛ¸b#lÜ»ûrú*gðíÐæoe09«xI2nêd+ÀØe†GûÈŒ™à÷oÝÈE:oŠf³5ßºí8Þø«6:eŒ,Îñ1›ÄÆñìÚéW}jpW|Ï²èXÖ:ÄÛ,’+SnOâNKê»!f±´8ÙoÏi¶Ñ]ç´v¢Ÿ£èãu6cP¶if»™é$©&Ücl-âfÈ‹¶ÛzþDTÃ¼ÛÎWµ<Nùtøðm\\[þ»ú¼ë}CVáÛŽ·4µ–™fµˆì–4Tk»ï¿g¨Ï‚2Wig„ñKè²ø•ˆ¶ñ´ÄùÄÿ\0ñ[‰ðÚ*z¦\rOw1w+•†AÊÏK†ÎÝ<cÁ6röB:iv¿<ÌÌ­êxôßM:jc¦<s;ôß×yê“‡Ðü^/=FS½ú‚[[¶þVºË8¯›·—uTÝ\r©§ŠÅ£ó!Ôñ›æÉŠóXÛV\":íð¡ßð³kBÔÒ	jxjÒzK–ñêuÎvîM¸®ë\"š[IYÇÉè±‡íZkmªå¬Úý&<¶éÿ\0¦L×‡1åáÅOg-m¹ì:¹Õ³q¤M•Uëº£Øé«M¿öfúnmºÏ4yµÒñÉÁ9\"¸ëàåïN»~“¾û¦iC	µ—šÌùLåäFÙÉ[VóàŸÈÆµ\ZÖ3²vC|Zx¬ïÞÓæƒ_Æ/¨¥qDW\Zv­Ö}e“Zè¬v«ÇÁZÔ²Õž¤Í³Nä\n‰$R·Ý7Ý6ðFHëäÓ…qlš+Í«h´m1=¦xÏ¢¯ªêj›ù›¹\\µHÝ]c¤‘ìö:?+#cx¢#×²{‘×Kµùæfes?›i­¦¦:cÇiß¦û÷ß¼Ï^Ï1xfúïÏÏÞÃÕÉÌëéBHÎ£þ§D²±Ëÿ\0§ùºí3Ëiˆ–mÇã%+±S-±ÆÑiæ‰ÛßiêÝ!c‰‘«Ý\"±¨Þoú²z®ÛwRÜ<ý§yß³U¿á®þ¸­«ì¬»YFVòôUñîŒ‘{rÝ»öïìV¶–³“ŸÍÚÃÇ³ãÑÎ–»rÛÏÏiïZƒ@Ç‘Ôê<vNÎ5?ë5Ò7¶H·ßŒ‘È×5Û÷¢š}íÍµ˜Ñq™Å‚pd¥râ™ßiß¤ûL>æ4Ît”ºw\'—¹e³ÈÙgºî’Jî/G£6F#¨¨¶ÓóS–fM/ð5QŸ:WhÚ+×nÛzïºFoDãrù\r¹e’&iùzõkÇÇƒœœxsÝ|¼;lm“Zk?•“‹dÁLµˆ‰ñ£iŸ?=öúî6‚gñºêÊ™;,MpÝªÄÑÍjÕFnæªµ‚o·sYÓþ\'<NÉ«Æ±ýÖÔ­«3×x™ó÷î×¤ð;ìe¬3sÙð“Î¶›bÂImù»‚¹éåM‘~þ¤?p¹y§•Ôµ×Œ‘—ÂÇ9¢¼¼Ý{{uèé ezñAÑ\ZÆýš›!z#g“½ù­3>jŒn”§CSæ5sHë9–ÀÙâvÜðÑôÛÃdßº\'}ÔŽ¸b/6õ^ÏÄm“OÄrâæÛ×âÌ”§‡ËærpM$’æædó±ûqb±²\"íßÜcÃ™ŸÌjø³âÇŽb\"1DÄ~¾ª:¾ÉŒ}ˆ°:‚þ#jGK&:ìcŸëÐt±½Ñ\'Ø†4¼¿-¦#ÑÑÉÇã.ÓŸ\r2d¬mÍ<Ñ¿ýÛLn»¹¥)ÚÕXÝFù¤KxÈe‚(“$È¨ªîÛïßØšpÄÞ-ç~.%ji¯§ˆŽ\\“ïÑŠ\r‹fw=–•ÏuQAz¬›tºqEÑÙ»\"/™¾½ÍcsZ3{ñl“‡(Ú<	™¬ùï3¿ðÖ¬ø/RÎä3j“°Q»<~ðíïºnþžÖÿ\0*/d Myy§•×§Ú«W/±øÓÞÝzþ›íòèpÄ‘BÈ“ºFÔj/Ù6/CËZÛÎþ­&×†V2þ]–ÔÙ<Žš=øùVtœ]É,ícdswOMÊ“¥ß¤Úf¯AÆ+x˜°c¦m¾hß§Ò»íµ~‡¥óì†jsÕµ ˜ßÁàÞ‹ô¾/*ìôÛ±\'ÓoXÙN8½ü\ZašÖÕ¦N~»õöŸdlO‡éu™Ì¾ZÖnü:­E°‘FÈâÕå‰­äåEÙ\\¦´ÓmnkLÚSjx×6:â¤ÛšvÞw˜úÏod|?…øúºjÆBÎCOYk™>t:ŸÔW2F5®Wsó&þ‹ìkM$Ef›ïTš¯´ÉžºŠÒ´Ï^öúôÛ¶þp\Z;+‰žª?Rß»¤œ`£;`Ù[Ã‚$²64‘ûz§s|x&¿â™ˆWÖñLy¢ßƒJ^Ýíß^‘¾ÐÏÑT)[Ô6cžW;Q;•¤w£ò9Ÿ‡Ûòw¹šàˆ›™n+|•ÃYˆüÞýwê¯›Ã<Lº&–’[S¥*R6XçòuUY\"ÉßËÇÕß‘¤écÃŠyBÍxþXÖ[UË^kFÛuÛ¶Ï9_\r ¹šÉdªeîã›‘f+VXøÌ‘·ƒvsÚç1xö]…ô»Úf&c›»m7šb¦;c¦O\nfi3¿Mþ“Õ’\rk‚Åâp¹û¸Öã,m‘†NªLîKÕcØ­Uoòªz>Õˆ­¦6i~3\\™¯—6*_ÄÛóFÛzLOî¶ÒZW¦1	¤ù%jÈù§±:ò’Id]Ü÷*\"\'ý	0áŒuÚ¸—¾¯/‰}£¦ÑÚ\"<—$ª\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0ÿÙ',1,'http://localhost/Trend/trunk/private_html/'),(4,'Factura electrÃ³nica',150,'ÿØÿà\0JFIF\0\0H\0H\0\0ÿÛ\0C\0		\n\n\n\n          ÿÛ\0C\r\r\Z\Z                                                 ÿÀ\0\0È\0ÿÄ\0\0\0\0\0\0\0\0\0\0\0\0ÿÄ\07\0\0\0\0\0!1\"#2AQaqB$Rb‘±%34ÁðñÿÄ\0\0\0\0\0\0\0\0\0\0\0\0ÿÄ\06\0\0\0\0!1A\"Qaq2‘R¡#BrÑð±Á$3báÿÚ\0\0\0?\0þ©\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0•Èú«’±Œ­\rÌµÊûÑãk>ÏCõ#›ð¢öð‹¹žÜªÄë¼Ì|œšøã%¦˜ëoÓ×h¯WÙÑ}CÓ²iz¢Œ‹v&ªÏiÆV¹¾Xæ?wûÌ×£®;Ä#þ	ž9Uã^:ooO—ßqì½Æ^!©~6«c·s±®ò‰#QÈ‹·ß¹um¸ßÍÍÏ†qäµ\'Ö³1ü>½º—¶{´Gí½>·²óoW¦ŠWðú¸î¨›žõFõîóÊ¿G^§£zß¶þ[ù»ž«\0O—ÕüfKŒ{%±É½[^µv£Üo×+÷V£coÝTªùb³ï-Üo¾lwÉ\ZŠcõ™þÑ9Ÿ’àµ…˜Íú‡ÄeÝ‡’;vòL‡Úd¯J´–ÈÎî»!Ÿ\'&µžžó?G_‰à™³âóc¢´Þ·kE{ü»¬tÖ©Áj\\w¼0ÖRÍdzÆõâæ9¯oukšäEEîY‹-o«/?Ãóq/Ñ–:mëû-‹€8Ü»J•wÙ»<u«GõÍ3Ûü¹Û\"M¢=VbÅ|–é¤M­>ÑÞ]öHÆ½ŽG1É»\\ÑQ|*)ê\Zí/ ðƒQë\n8,ž<2Mc9cÙ«$|~•¼žþJŸy¦ûåÍ˜êtø>~F<™\"b#w;ýûeùs˜“µê^½ìL27îcœÖ\\J4å²Ö+Óvî±ï¶æiåWªc¼Ì|¡ÛÇà9§rÍ±Ò·ôê¼WËE‹È7!B+‚zÍ—uHmFèfnÊ©ñFîíñ¿rú[q·+‘‡Ê¼×qm{ÖwÊQ%\"ª\"n½‘\0K!Bü=z6bµêÞ¬/läß)»USt<­¢}eÃ|s«ÄÖ~±¤ƒÕ`\0\0UjmM‹Óx§å2n{j±Íå±dr¹ë³Q\nòåŠFå·ÀÉÊÉåã×W×·£®k=ŒÂáçËädèÓœÞ«õ.ÿ\0KQ¿w9WdOÉíòEkÕ>ˆqxy3åŒTÚgþþÎ¸œ‡¼qðÝöiª$íäØ,µ*\"øäÔWm¿¼žÒÛ¡ÉÃå^i¸¶½ãÑ,’€\0	¬);Z®“dºã)ût³§“YËŽËß–ýÓí÷)ó£Ìè÷ÖÝ?ðËþSóS1Ó×Ó¯uùs˜îGEŒ}Û1UdŽHãtÏlhç»ÃQ\\©º¯àòÖˆõ[‹òv¤Mµò¤ª@Îç1¸<MŒ®J^•JÍä÷}×ìj}Üåì‰ù!“$R7><>&NFXÇŽ7k:brñÇÃwÙ¦¨“·“`²Ôd¨‹ã“Q]¶þvò{Kn6\'•y¦âÚ÷D²J\rÕ§êwé¶¬‹“Ž¿µ½8;¦‘ªñOÆýÊüØëè÷nŸÉÌvòæÝ>½÷ö[–0€\0\0âe‘!zÄ›ËÅx\'ú¶ì%*ë}ýèCk¯§ÐXN÷ìY³&Mëõ­Ž«“ãûïÓF˜|?ÿ\0«ë¹Ûéÿ\0M¿=5ÿ\0DV½?m{~ûcõ$qÅ’õZ*=¨-:’Yk~„´æ¢»û®îUý™rúå×¦£ùwx337ý}v×ûî’ò”µ–ôã«êê³_©\r9&£4›Ò’¸3 Úû#SŠ=>/=—ûNõ¶<Q~©Ükì£—3Ÿ~-°Ò)i¼E¢>8˜Üõu}uéè™Û=p±ÿ\0qÈAÔÃ6öñÍÅé½¦|ò{ý¼½ò=gôïû¨žgGƒÇÁŽu›§Óÿ\0Ìü_îú«¬êMC¨rZ’xäÏ³Ýö¦£…‹ÏðÑ¾Èë;*uçlªÕðŸÛhN[^mú»N£_ûk§˜ÁñÖ-2~)ßôüµóYjLÎ²³†ÐpÍjÎ-–¶Ú¹E:r‘Ê¬^Ýþ¤EBÌ·¼Öžµ™žì|/™yS®\\xéÕ_xùúÿ\0ežÆOOz>vNÞKgï6²ô‹<±JÉV5F=ÝöTjöý“¤Í3tîf:wÝ•L|¯ŒýÇ–¹z>ÔLk}á‰§¨µŽw	6¦¦¹÷j	¥{±¬§,Sad»t¿Ö›5wUûÿ\0}òFKÞ½qÕÕíò}^š8÷ò<ˆ‹ªÌÞ¿WÑîØéç±­bÄKóDÇËöV=ÍEsWø^Çf³¸~ož‘[ÌDî\"g¿Íäx¬ž¢—Õ]c–Âa½ï$	27­ˆ«Ç\n±©ÉÍy9ñoð¢œÊZÞuæ±¿gÜr8ø#ÃxØ³dò¢wÓ6™ßÛé>è–púIÖÓ˜_x,Y½SŸ[¹Yi9X‰ÂÙcoÒªÔIWöBil}5ßÅ{ntºœ¬ÛfÍÑ¼\\|4êù÷Ôýû5Ös9;^µÓÃÖ·+q¸ü[í]ª×*FùªÄWµ<ì’1SsTÞg‘Óíáãâã§„[-«eòôÖ}õûÆc§Ïç4Ž±ÕÖu&J­jÖ.;Zµ‡DÆôþd{ªnåb«šÄnÿ\0“%f×¥ïÕ>ú}zaãò¸üZáÇkZ´ë™®ç¿iýýgoÝw&O=é¾‡Ží¹ýã›±V´±µÛG3fïÔ‘‰õ9©ü©ï#wÅMúÛO<1ñ¹ü©¥kÑŠ¶Ÿ¬kÚ\'Ú=†‚òædÖ4½<Äæ.×¡eÈeòn“Õ]³aŠUoÀÛÝïúÙn·W\\b‰ks>î^*8–çåÇI¼Û¢•×Á¿ê˜÷÷þ4=ÜÍS5•vFÎS\rN´Va–äia•ý5é¬‹ñ.é\"ùüÁkF[Ss5ˆ÷Wâø±dðü<žŠãËkLOLj&#}õûtßQ³ÙµÎ`4†ÊÐ¹œ|Žµ}©¼‘V…9?§¿õ*#»þ¿d¹9-ÕZW´ÙŸÀøx|œ¼¬Ñ×\\1\Z¯´Ú}7ôôþY9°¾îõŸRl­Ü®?›(ÿ\0xJ¶$‰ÊÇ±Û9v^êÆ?c4ÓYâ73îíW—æøNKF:c¾\\‘O‚:b{Äÿ\0îaY¤ÖZ£\r=ê²õÁA‹S#wlŠŠUUj£•P„eÉ’³o‹~Úôl·‰ÃË\\ùy¤Gù“yÿ\02wòþŸ£ÛtüÙð8ÙòLXò2Õ…÷cTâ­™Ñ¢Èœ~Û;~Ç[ÏLo×OÏ9µ¥s^1÷¤Zz~ÛíýžQéƒõ¥»:ŸPà ÆË_-•›wÞ–xß´J®b5\"ŽDâ‰/m×s›Äó\'ªÕ×y÷}·ââR¸0fœ‘lx£ôÅf;úúÌwì´×z‚¥¬•Ê•.çe½‰§¾B‚­g¢9ë$ò½X»íý<—²xßrÎFH™ÔM·íèÅàü+SmjàŠd¿Ã9cv´zj±ßù×º›­u–OMè½?\rå‡5¨–ÂÚË*#¦Ž¥y›·~Ë#£j÷ý~Wrªg½«Jïâ·¿ÑÐäøW#“žk¼X:uOiµ¢?¶ÿ\0óôk56šÿ\0§ôn~ësù™Þ”žæº{Šý¤gÆÕfíø9¹®ÛíÙ\r9qtRÓÕoO›‰Àçþg—ŠžVøý©®Óóùê;ÇÕ…}l–‘ôWo‘¹K7ì¬¯\ZMÆ8bE±ò\ZˆœUìM—¿s§&&wm>Ž2cæø½ë’”œxº·Û¼ôÇOÅö–×XdòÐkm¦èÞ™W¾l*,ÑWk\\M»¹Ó~ûšóZc%+÷|ÿ\0†qñ[‡Êä^±Ú\"+ô›|¿˜Tc™œÕ^¡j§K¨/ctÞxâöz“¬(²DÞ.N]ø³xœ¯ÛÎåUêÉ–ßÅjÝžpðø85†—Ï–&whßiÿ\0Ì÷3Ú×WÙu)u™Èê:—útïK#\"Å¹\\õù1@¼VF¢\"¢nÏ·rœù»uRoëû:žá•ëŒŠqãTïX‰œžŸªmí?¿Ù²uìö°×™LY)ñX-?MºêéObÌÉ¾Ý]¹1‰³“·ã÷ÛWU²äšïU¯ÉÀŒ8x<*gšFLÙ¦uÕÞ+Xú{Ï§óüò×>ôÀ·JiÌ^^ü“å³\rêZ±ad°µÛ²I\ZÉÙU‰ÔE<än5‰žöYá_\'ÏädÇŽ#H®«Õí:ùösÃûßÔL®vÕŒ½¼^ŸÅZ}m||:Hþ©å“m×ËUãÿ\0Ÿ)¼ónó‰Ôi.O•áxñV¸ë“>JÅ­7öŸôÄ=ÿ\0ìfÓ^ê¹=šÔ—e\\»òmÆã²L^ÊÄsdG#“nêˆöoø(üÅÿ\0/½÷Þ¢]oðn4x¼V+Tbëµ}£Ö?âWöáÏé¿P4n><ýüœÙD3Y—œ.HØ‹Í‘vk<»m¿Î÷LZ™)S;õs1Û/ƒÉ¼â¦8Ç®‰ˆïÞ}&}ý¿–ÇÔ­Y.•Ñ÷rð1m¼bª×}=YÅMîí¾û\Z¹Y¼ºLû¸>á±ÌåWþŸYûGýÓÏ±rë¨rÚrzîÔsÛ–ÔLÔI‘‹j=UWGêØÒ=×nÆ*y›¯ëÞûïÑõŠðí‹4[òÑX¬ù}ñî=7>ûD½«%ÃêoQu|l–)-\\F=ôõWå¿ÓVJŸrÍÓ|—ùjbðØÏÇáñgµmÕ’ßoXþw¤¼\\ºê¶œž»µöåµ5dbÚFUD•ÑÇº¶4uÛ±:y›¯ëÞûïÑO\"¼;bÍü´V+>_Dü{MÏ¾×Xs^ fsvåË\\Æiì]·P¡S/³É+ãúå–V§>ûµQ?ïn9¶kLîb±:ìçó+‹Ã1b¬c¦Lù+×i¼uDoÒ\"=>÷Ò«Ô6¶5–†Ó‰•ÈNt’LùgäôJ¿1&O…>j¢½9íá¯“‹w¥w-¾Ïéâr¹^8ôÖ£·ÅÛ_íôìívž ÌzœºNŽ¡ÈÒÄb1‘®Fh§_h‘Îw4^~Gu[ñmám¶nˆ´ÄDwW‹.ù«áÇl¹2OLL|1íéòí=¾rë§¡ËkË™‡Oš½COaf\\n2:“tæ–HÞÍ‰¶ä÷mÅÛ~WýýÇšg¼ÅkÚ?æPæÛ†×±ÒùòÇ]º£q?é¬{{Çýí@š÷UÉè¤Ö¤»*åß“n7’bð–V#›\"9›wTG³ÁOæ/ù}ï¾õéÿ\0ƒq£Åâ±Xò£]«í±ÿ\0¿·Mú£qñçïäæÊ$é˜‚Ì¼árFÄ^l‹³YåÛmøþwºbÔÉHê™ß«™ŽØ9|Mç1Æ=tLG~óé3ïíü d½DÌâò~ f™;æ­‹’¶7MîU–òäwô¬jåü·&Õœ–ùj!§‚bÍ‰‡Z¶Hµï>ý>±ß÷ÓiÑ¹\Z±TËç5&N|Œh–/Gí=:[íÉÑô8tÛþÿ\0ðjÇ‚câµ§ÙÀæx¦;Í±aÃŠ)=«ðîÿ\0~¯]¼ÛZêû.¥. Ó9C\'Rÿ\0NéddX·+ž¿&(ŠÈÔDTMÙöîaÏ›·U&þ¿³ë<+Ã+×9ãÆ©Þ±9=?TÛÚ³ßÏ‚sÛžßÞ7ý—æ’ý\0\0ceôá•òw/éüÍÌ¼_Ô¿Z¿JHõúžÖJÇôÞ¿”2þWSºÌ×nõ|w«iŸ3tF«3¸˜ún&7Gh}5À×Ò™\r;çFey:ýù’Z–Gy‘ïrl«Ûñ±ìqkšüÐ·f·&™ç_åþšúV#å®ÒZ®‚Ž:önýü9ì’¶\"e‹§¼Kd{X×½‰öj¯b“ŽÑ33XöjŸÄ–Ý²S:f¾÷xÞûü£z‰ú­rú·5U}MK\'cŽ§a!HÞÉ«£úœ’5Ûn¿rËàÝúâu,\\oèãOô­é6êïµµ­ö”iý;t9›ÙLjÞL›º™\nð6a‘ÿ\0y“1üíû¹Ïâ™¬Íwê¶ž7¼UÇ›2Æ?Ó3¸˜–âcqôOÉèÊÙ\'`nå‰&ÀLËLîæ{y~Nûn»lNØ:ºwþ–n?ŠÛ›­b3DÆ»ö‰ù;¿JS~²U,Ò{dt}Þvéôú‹//¹nïÉ/&:úýõ¥qâ6Ž$ñµ3~½ûïZQÕôÎLcìEÔñ»R:Y1Ð¤cÿ\0=KÝ1Åéý6˜“£“Çã.§>\ZdÉX×TõFÿ\0Ý©¶éãóû5¾yC¥4}8¹7×š[e®IzÌ³m¿9?¥6Dì‹¹N1Mýgn—ˆøù]Qé}õ–†¯©fÆ[K³ã²Xy]5pqUj¿-ÚôTT^G?¯S½L-ð¿·/^˜½2Æ­ûü¾èºÓŠ¸lÆO3ïK·²YX:Ù²±¹íññ7‹\Z‰ô¦ÉáãâÅm6ÜÌÊîoŽÛ>*bè¥1ãÄFÿ\0åù¦8šú]\r©ÙJmú–Ó‡YyMÕ_éãöããÀŽ,F?/Ùíü-¹±Ëš×ª=»ëÓ_¯Ýõ¨}9¥•£‚¯^ôøùôê±q¶\"F;n›ZÔä×¢µñ¡îN4Z+ß]>ˆð¼røo–mX¼gßTNý÷òû¾s>œE{+O9S-ož©]*¿#IË36U–77‚ªÿ\0÷Â_¹‹DÌZ=ÒâøìãÅl6Ç[áµººg}§é;ÚËIè¼VšŽÊÕ|¶nß“­!eÜç™ÿ\0—.È›&ë²\"aÁþòÉâ^+“—1ÕªÒ‘ªÖ;DB6¯Ðu5\rÜvI—\'ÆåñNWS½_Š¹ÞZæ½„sqâóé0·Ã<bÜZ_Ö2bÉëYÿ\0ø§}4¡ˆÔ³Ód-e2*ëZÛî,jŠ×+UÛ#\ZÍ“àDDðˆG+i¶æfVó¼zùðWR¸éKn:wõùÌüÜ0¾™ØÂ5)âu&B®²õ›Düww%ce|nz5~èyN/Gh´ôü–ò¼~¼‹.vË­u|_Î¢u¶ÖxÖHd¬WµZo”Ý6Ý?ƒ\\¾~“©Ú›Fé*\ZS\ZŒ–œ÷õeÛ›–G+»ñDNÞ\n°aŒué†ÿ\0ñ+ósN[ê&uéôfïúCRÍÌÜfïÒ¥¨²ä©@±lùësÜ>5Ý¿s=¸Q3=æ\"Þ®¶ÄÖ­qDâ¥ï‡µfwÚ>ÛÖþ©7ý)ÄXÆàëÖ»fý<Îì”\nÔ—nÛóM¸»}·ÿ\0ô•¸q1æ&¾’§â<µÉ–Ö­oLóñV}?e&CLdpYŒ½¬¼{ÉméogÓ²FØØÖ#QY¾Ûœ¤ÖÓ3¶\\~+¹Í‹iÑíÞwëë¹Þû«®ú_GGVÓyµ«Å,sQ½´l’…8šˆÖì­kwóßöBÜMÓ¦f{5büA8¹sÈ¦:Ç\\LZ½æ\'s¹þÿ\0·Ñ×é´TõL\ZžîbîW+ƒ•ž—\rº|\rcÁ6röCÚqu~¹™™C“ãÓ~4ñ©Ž˜ñÌï¶÷ûî{¥á4+ŽÎRëMe5ÓÏ~i©\'ø–ñsZ­Dì›ª§òK+Ô§—ã93_õòb±XöøYè=¦•ñ”ìçoÙÇáì%Œ}t[vz¿g¢3wªª¯Ä«ãÁDpc´uN¡Ô¿â»õ^ÕÅŽ·Ë]ZÝ÷é®Ýû}–×ý7cµ%C†Ì[Âß¾Ôeô\"’)QmøJ×\";·’Ûq~.ªÌÖe‡Žÿ\0ñã\\tËJ~î&?xŸDË:\Z­¼Î-rí‹V4üod	\'\r¥{ÙÅe—f§ÅÙ¶ÝÐ”ñâmY™ý*)âö¦,¸©ZÖ3O}o¶§Ò;ú)æô’¢ZÉû·5Ì½dÉã«¬|®ß—MÎbº>[÷ÛøðW<8ï©˜‰õ†êþ%·M<ÌxòdÅ\Z­§}¾ýû¬ršiûXÌ&*.u1¸;1Û‚¬{+d|}þj¹W}×uóÜ¸µ˜ˆö¬²áñìôÉ—,êÙ3Vk3>Ûù\'[Ñômk*:¦Y¤ö¬}wÖ¯_áé|Î\\Ÿã—-¤ÛÉ9Ãx¿ÉŸŠ^œKq¢#¦öÜÏ¿mvþÉ\Z«Lc56Æ$Žök|q®Ïcš»µÍ^ýÑP–lQ’½2«Ã¼C\'4eÇú£øCÓú[/Œ±îj;¹H bÇ\riÛ[²øYÆ#är~UÄ1âµ}m2¿›â²Öb¸iŽfw3_Ûs¨þ­ô£O;›ÄZ–{Î[uë6\\­I[+•ŠÅFíð¹7MÓî¥“¯L×ú§msø?-b+äÓ¦#Û_U–ŸÒÙ|eˆßsQÝÊA8kNØ\ZÝ—ÂÈæ1#“ò®,ÇŠÕõ´Ë\'7Ä1e¬ÅpÓÌîf:¿¶çQü*cô¿ØrWí`s×°õò’,×iÁÑ{:Ž]ÕÑ,ŒrÇý¿à¯òš™šÚcm¶üAæc¥sb¦YÇ\Z¬Î÷¯®§ºv£Ð-Ëêv ƒ)g’ÇFè,)¹Fýùv{UU½ÉeãõZ-½L3ð|gÈÁ|Jßç}÷ëûOÑ3£èã5&gP6i&»™éuRN<cl)Å\ZÍ‘m¶óø\'L1[M½åG+Äï—¢+‹~žûù¨&ô’¢ZÉû·5Ì½dÉã«¬|®ß—MÎbº>[÷ÛøðS<8ï©˜‰õ‡J¿‰mÓO3<™1F«ißo¿~ë‡¦š~Ö3	Š‹LnÌvà«ÊÙš®EUßuÝ|÷\'n-f\"=«,¸|{=2eË:¶LÕšÌÏ¶þIÖô}ZÊŽ©–i=«]õ«×øz_3—\'øåËi6òNpÄÞ/ògÇâ—§Ühˆé½·3ïÛ]¿²¥ž”i×`óX‹RÏf<å·_µaÊÔ•²¹QÉÁQ»|.MÓtû©WäëÓ1?ê¶Ïâ<þv<µˆ¬á§LG¶¾©X­vµ9¨duì¦>Z’QmY’#b‘8î¯c9¹è‘Ê¤©Ç˜M¦cZSÈñzZÑ|xiŽñx¶ã~±÷D}Pz+M+ã)ÙÎß³ÃØKú.è¶&ìõ~ÏDfïUU_‰WÇ‚˜àÇhêC¥Åwê½«‹o–ºµ»ïÓ]»öû= Þù0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0ÿÙ',1,'http://localhost/Trend/trunk/private_html/');

UNLOCK TABLES;

/*Table structure for table `productos_users` */

DROP TABLE IF EXISTS `productos_users`;

CREATE TABLE `productos_users` (
  `User_id_PRUS` bigint(20) NOT NULL,
  `Producto_id_PRUS` tinyint(2) NOT NULL,
  `fecha_alta` date DEFAULT NULL,
  `correo_cliente` varchar(50) DEFAULT NULL,
  `clave_producto` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`User_id_PRUS`,`Producto_id_PRUS`),
  KEY `FK_clientes_productos_clientes` (`correo_cliente`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `productos_users` */

LOCK TABLES `productos_users` WRITE;

insert  into `productos_users`(`User_id_PRUS`,`Producto_id_PRUS`,`fecha_alta`,`correo_cliente`,`clave_producto`) values (1663670023,1,'2016-07-01','benjamin_otero@outlook.com','');

UNLOCK TABLES;

/*Table structure for table `users` */

DROP TABLE IF EXISTS `users`;

CREATE TABLE `users` (
  `User_id_USR` bigint(20) NOT NULL,
  `Nombre_USR` varchar(50) DEFAULT NULL,
  `Apellido_USR` varchar(50) DEFAULT NULL,
  `Correo_USR` varchar(50) DEFAULT NULL,
  `Idioma_USR` varchar(20) DEFAULT NULL,
  `Pais_USR` varchar(20) DEFAULT NULL,
  `Zona_horaria_USR` varchar(100) DEFAULT NULL,
  `Pass_USR` varchar(10) DEFAULT NULL,
  `Recibe_news_USR` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`User_id_USR`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `users` */

LOCK TABLES `users` WRITE;

insert  into `users`(`User_id_USR`,`Nombre_USR`,`Apellido_USR`,`Correo_USR`,`Idioma_USR`,`Pais_USR`,`Zona_horaria_USR`,`Pass_USR`,`Recibe_news_USR`) values (1663670023,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL);

UNLOCK TABLES;

/* Procedure structure for procedure `Productos_Usuarios` */

/*!50003 DROP PROCEDURE IF EXISTS  `Productos_Usuarios` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`ncsoftwa_re`@`%` PROCEDURE `Productos_Usuarios`(
in p_user bigint(20)
)
BEGIN
SELECT * FROM productos where `Promo_activa_PRD` = 1
;
SELECT `Producto_id_PRUS` FROM `productos_users`
WHERE `User_id_PRUS` = p_user
; 
select * from producto_top
; 
END */$$
DELIMITER ;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
