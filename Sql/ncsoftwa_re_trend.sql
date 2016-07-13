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

/*Table structure for table `productos` */

DROP TABLE IF EXISTS `productos`;

CREATE TABLE `productos` (
  `Producto_id_PRD` tinyint(2) NOT NULL AUTO_INCREMENT,
  `Descripcion_PRD` varchar(25) CHARACTER SET utf8 DEFAULT NULL,
  `Precio_PRD` float DEFAULT NULL,
  `Imagen_PRD` longblob,
  `Promo_activa_PRD` tinyint(1) DEFAULT '0',
  PRIMARY KEY (`Producto_id_PRD`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=latin1;

/*Data for the table `productos` */

LOCK TABLES `productos` WRITE;

insert  into `productos`(`Producto_id_PRD`,`Descripcion_PRD`,`Precio_PRD`,`Imagen_PRD`,`Promo_activa_PRD`) values (1,'Gestion FREE',0,'',0),(2,'Gestion PRO',150,'ÿØÿà\0JFIF\0\0H\0H\0\0ÿÛ\0C\0		\n\n\n\n          ÿÛ\0C\r\r\Z\Z                                                 ÿÀ\0\0È\0ÿÄ\0\0\0\0\0\0\0\0\0\0\0\0\0ÿÄ\07\0\0\0\0\0\0!1A\"Qa2Bq#Rr$‘%34‚¡ğÿÄ\0\0\0\0\0\0\0\0\0\0\0\0\0ÿÄ\0:\0\0\0\0\0\0!1AQaq‘\"#2¡ğRÁÑ3Br±á$¢ÒâñÿÚ\0\0\0?\0ú¤\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0K¨úáÚSê×øÌÆFd«Œ©ìé]îïÅ;vO*¨Ÿr¶«?‡:ÌövøûfYæ\\TkO¹ì\'\\GãÓRÓ“ Ÿ?ğo„‹áÿ\0±,l’oÿ\0Ûøz·æı6tcWÁæü\râŸÇÏ;üy{~û?!êu¼¯KòùúŒJÜS]ºêœ’;Ûº5ûüª‹ïû{ÕÍ°Í£¥¡›p\náâ8ğ[ïáÉÖ\'Ö¿&æ‘êÎ“¹‰ÅA”ÍÖLåŠñ-¦/ÈßYÍîŠí’6®şÛ›aÖRb7˜æAÄı›ÔÓ.IÇŠŞZvóéşì\Zçªpiıc…Â6ÅxëJõvjY7WÃÈ¬O¢rGo¿s\Z_%â¿Tœ#ÙéÔérfÚÓh¹·œùı¬ŞµÒ˜:ğXÊäá«¦ó¯ÉU\\ö¯êk»•;ùØ³|ô§yqtœ+S¨´Æ:M¦½ıß>ÌØS§³8é28ËñZ§ş´¬_ÉÅ7^m_™½»÷C4Ë[Fñ=êxv|ğòVkiíïø!ßÕœ1bEÏVşwäÙ\\¾û|Êˆ¼òØ‹í˜¿ŠãÙ½|ïøVéûùü“ùîŒş)rä0ã¸£ÒÓßMÈïËÅŞ—¶ŞI­’±Ïg7.\\k3Mº©}/ÖÒj	¯®C9RÕÉ$sêb+\"7Ğ®‹Ûæsù¿uï·î¥]&~}÷˜ßÑßöƒ„Æš+ÉŠõ¬G[Ïœıf!Ğ‹¯.ç½5×7²X­AÔW\"e|fBX;Ñ±±nJ›\'•÷)iuh´ÛÊ^£pŠbÉŠ˜+;äÇ·YŞSX¾§h,¥öcèæ –Ü«Â(—“9»Â5ªôj*¯²\"÷%®¯§h®~£Ùın\Zsß¢±ûòZ:;¨p¹¦Îì]¶[JÏô§áúŸ¥wØÒ™+nİVµZ,Ø6ñ+5æãàÅÕšk!±“§‘‚\\}G+lÛå´LV¢9y9Û\'dT1\\Õ˜Ş\'¤7ÍÃu²F;RböírĞÃõ#Cf/¦?˜‚{ìÈ~f+Õ=™Í\Z_ØÒš¬v¢z¬êx³9òc´W×úíÙ“9Ô\r‚´ê™l¬U-5¨õ…Ü•ü]ávj(É©¥\'i–ºN«ÔW›&ÕõxÉõCââ«-ìÄ6ìM²|Îs¢zn×ñj+‘«ìª‚Ú¬uï=Ûiø³4Ú)g–vŸ£ÖKRP½¤.eğ™ŠĞÄØ×ÓÊ/ób‰É¶üÛßÆıÑP[,M9«1ñc‚øõUÅ›¦wü½¦~\r{\Z¾DWËä²•lØ’ª:J¾”V§á»x7ÎÎ_¢vCš+y˜íõINlúÉÅ–­bİc¼Ö7óø5z]©¤Íá÷sµ³d^Vc¬ÖÆ5+xñËıÊ|\Zi2óW¬ÄÊht§Íµ1[?-úïúÌ|›6º©ÓÊª©>r»\\×¬Nbrs‘íó»ZŠ©ûø6^(óCÙİuûb·mÖ:\n9\Zq]£;,Ô9E<NG5ÉöTû–+h˜Ş;9Y°ß¦—‰­£ÊT¯êA€Æâ	eµl_¾Ê¯‘ñ¶Tâö»ÙÛû”õ¹mH_9zf8~\rNL4sV˜æİöGêDêöœÃYÎÄ4²qPo­=9)6tmüÛ9«¿dû¡¦_•ææ‰ÛÜµ şËÕeŒ>\rñÍúDóïÕ§Ÿê©ÉYÑ1éûLÅ&§‰îŸÔ‰–8=8ÿ\0RwD]ş›šdÔŞÜœ½9“è¸.›u3³“ìóm3]û²êÛ][Ò8i3òghåªSV-ª’TlµïF&ÊÕİ{»ê†Ù§>:ósDÄ{špÜ|/[–0F+ãµ»O6ş[¤µOR²£§©iº­›PêˆcœSÿ\0Ó‚)Y$ÛmöİÙWÛeß.ªv¬Wó]S‡p\ZMó_Qm°iæbvïi‰ÛhıùÃW)K­8<k³\rÏÕÍ¾³Vkx‡S&«İÉ‘£^õDñ¾Æ·®zG74[İ²m>^¨ÉáxVÅÍÒ/Ï3õ‰éªé£uM=Q§jfª5ce„_Rî±ÈÕâö*ößeNËî…¼c%y¡Àâœ>ú<öÃn»yúÇ”¦‰\\ğ\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0¯­|¨e´f£™ªìf##ş¹È›ğI‘İ¾‰\ní÷9Úî“KyD½Ÿ²Ÿ‰‹S§ñ2cû¿.oêéOÊã\\›­D˜äg«ñ|Ûépş®~6/óÆÛù<”i²NO–y÷Ûmºïğp¬+d·Ó®¤ê1c¡˜µ4´‘SmØ’+•SíüÍ¿ÁÇ§\\Y-å2ú>ªbšı÷ÅX‹}?á»o¤[øwÊCª°2VØÙ¾¯Æ¬¨ù¿7.[·û{x7šSì¿¾êøõ:©ã¼»Ûni¼¹6ıÏÅæücPt¡ùZû6j·âıF¢ºM¢oS+·ÔÅ£{bßÑ¶òà×Å\'îÖİ=İg³òä\Z×\\s1c£ÄÉ~µh“e&X›G\Zÿ\0¦l_«º¯ûıÄÅ§Q;rï·Mÿ\0‘Šø)ÁñÎIËµ§›ÃÛ}÷ŸÍ¿—ü74î-Ö:¢{·p±Y±Š›ãğØ‡Nœ_ÅªÉV)\ZˆŸ›õxîoÅí¼×òö„\Zí^,º\\JæšÆXå¾N_¦ñ?ËËÜÑÒ8,;¿¹[o§íM¹Ÿ;˜Šşp¹R5åçåâ›\ZaÇ_³LüV8–³,qÌuæXšFŞéïõDjä&Ó/­½wT‘²dÿ\0é˜æ64±Ã¿EÛößØ‹&ü˜½=ı—´QJê5ÖûÜÑüsí×~]üÖ,ŞÕ­ÕúböbÎ™Ä]‚Ó¢P[PÍaˆæ£¡ÙÌr96ùQ;yÛÜŸ&;óÖmÉ¿–î^“]¥û.zbNZMg~nIŠÏ^½úzü°ë>zùË‘ÀRéî§ş5EùgÔ.†½FJø9OÃ“yHÏ\rDb¯¹Â­«­Íı÷Õ³àÏ“]ƒÁ´RcO¼ÎÑ=7ôŸ‹\'PY©á“K&_‰ÃFË°¥\n´U]m\ZÕM÷r|¾›{x÷ØÎ§Ÿîï¯_.í8,éæ3øWË–y\'šmù®ÿ\0ÉôIÜ|±óî«ÍËÓÍc¬ªÄŠÊú’—Äãöö±+¸òOdâçÌ¿á.l\rïÅ?WÓøv’8¦—Miï‚û[ı1ıv¯êk<½?Ñ9DôÛnä3åynå;*6^ø·åEÛúPÆ|sM=cÖzœ+Y]OÍ~ü´˜§Êb:oóú¶µ¾˜Õ“a1¯ÉO¤°µkË±y\ZknµväÆÆşN+ù¼}Íóâ¿,oá×Òz¡á<CM\\×Œq«Ëi‰æ­¹\'ã¼o|¿DÚcê^ü@=·áÇ¥ˆlœ\\Ôs9ìÖ*ìï³Ô—–\'S×ø\\ÿ\0\ZØøÜ™ómòïüšùı?}½MÈd4m¼eÜÄu#î¿\Zÿ\0.&ÇÒìÙZŒğæí¿ÑMrcŸgÓ;v”º-m?³©M]rWŞyrV{Îó=|ı|§²:†S7M5æ.+pyrÿ\0Í+C+¦Ó=ÊŞLäç#vX•8··ƒJŞ<+ÆÜ³Ö³iòWˆirNO—ü³1´í¾½ûÏV¶2\Z–õwL©åÑ$ÅcëÅ/xkŒ•¶û¶?İv5¬Dß[·/ê—QkSK­¶.™<ißnü½?öıVKUéÒüBâÙˆka[8ùW3;5¿’Uj½İU±¯û)bb#U¾\\œw¾NyË×—$roñ¯oû¿V—H0X{˜­ebİ8¬K-ë5ÜéX_IËŠoá7væš,u˜¾ş«Ók2Ó&š+iˆŠVzz§ÿ\0rôâUUFÙ\ZŸDå¿oò¤Ü7ü/›™í¬×ÏújÒüA2I1:y‘ÉéHü´Md¨›ñUc¶vßcN%Ú¿êXö.b2æ™ëÿ\0¼$r-ÔYzÿ\0œÖ—nc^©ëÕ`æˆ»ì®nı¿t$¶’ÖékÌÂ®hp`·>5+“Êw™Ù^ê^ëNŸàñóK‚4–½y«/bkx\"+\\»÷íäƒUñ1Ö::œY?dÕæ¼Eæv™‰í=Ñz÷M\\ÓÙÜLº¯-‘Ô\ZÌÉ†Í;ÓÑ›ô¬ˆŞÎO~È‹¶éûÇ¨Å4´sÌÛ\Zç××U‡$i±ãÃ«¬tÚ#¬{½?øÖ3RÁuwHgçáZNÇÃe6ôbvÒ£’|­nÓ·¿¿blÓÏK—mœŞ[ê8^£o9¢üósùñŸ›¤êö/„³•¿+RÕÿ\02¦Ï]·kõWxD/äÉ®óÙä´Z<šŒÑ‘<Ó?OÉLè6İ.Wu†«~2ylÂÕóé»fµÏ\rÓ÷*ğêÌbø½¶yë“_<¿å¬DürèÅç”\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0‚ı\nY\nrÒ»,Ô¼f†Dä×\'İÅ«Od˜s_¢ô™­£´Âé÷=¾\ZÂÔçê%³7¡¿öòßÿ\0e?°bù|^‹ûİ®õ¯6ÛsrÆëeÍ9†·~õšÌT‘zZ/åµ#OÒŞ;mş6ÅY¯/“‰‹]–™¼xŸÄ‰ßyëÕU¯ÑAf[JWÅ’FÔ’y_½?S˜å]÷Û¿²•ãA‹ÑÚ¿µºûVcš7Ÿ>Xßê›ÕzNjƒ\\œOIh*­IàzÄörÛtEo·Ê„¹´õÉßÉÏáÜg>›Ã˜Úıâcx–ÿ\0M4y)ºıyİ6*÷£•ñØF³Â:D_›ü˜É¥¥û÷„š.=©ÓsrLrŞwšÌD×éäË§zy¥4ı[pcª«]}ªË¶${¤šDvû¢½Ëºyö3MJvói®ãzM«9-ù;DFÑ&zZ\'ORÓiŠğ9¸yY$o…dz»ŒÊªÿ\0W—}ş¦k‚±NO$yx¶|šˆÔZ6ë´yvèÇk@éKzj\r7j’M‰¬ˆ•ãsÍ›xsdßš/;˜=&œ»tmŒêi¨Em¶Kw÷ü»40(Ñ˜L”y:õå±zãZkR¾oI²pG|©··nŞÆ˜ôxé;ù¬ë}£Õê1Î;LE\'¼V\"7ø®§	T^—èÇaïaİI]G!cã,5dz»×ş¶;}Ú¿±[ì˜ùf»t—kûÁ«ñk—›ïÒ¼±Ò;zOª6>ˆôı¨Şu§šhÜÇEbK3,Œôÿ\0+Z¨äÙ©¿ƒO°bıÊİ½­×Oi¬DùEcn«éqæ•ÍSÓí+ª,Õ±š©ñÓEHUævr¢ìî*œ“t÷ Ë¦¦OÍäêğş5©ÑÖÕÃm¢İú%òØ|f_6;%]–iNœe…şéãeEOeNèKzE£iì£¦ÕdÁxÉyoj–7£\Z…ÚöÛV[QyT†ÌÒKK¾ÿ\0+vóõÜ­]8ı¼şÕkrRkÍÍŞb\"&~kt®º™ú•\"_âïƒá77mévíÃ~>ßBo¼üşn\\ñßgû>ÿ\0…¾û{ş(İMÓM\'¨²,ÉŞ‚H²,oŒ­+á‘Z¶wÙ|ùÛsLºZ^wëz=©ÒÓÃ¤ÄÓÒb&(ôëIQÓ–´õj|1×¿ï>wz’ªûºMù{}L×MH¯.İ%¦n9ªÉ¹ío¿Nİ:GË³ÎW¦úG+ƒ¥…¹OLk”rK\"\"|²oËÙ7ÜÅô´µb³ÚÓqİVÖÍK}ëşn\'äÉ¥º}¥ôÄÓÙÆWwÆÙí=ÉŞéfro¾Üœ½“§Ÿs8tÔÇÛ»^#Æµ:¸ŠäŸ»^Ñ´6°:G‚¯v¾6EBWÏiî)$Mœ¿2®İ¾†ØğÖ›íæ‡YÄój-[dæ‘´tò†M5¦púo˜ÌLK\r6½Ò#ç=y?Ïw*©œX«HÚ;5×ëòêòx™g{}u•ÂêêÇ•‰em)Ûf¿¹›JßòªoäÆL5¿&t<G6–m8çnhÚ~	rUFSJáryŒn^äJûØ•s©HsQªı·İ¨»/r+á­­ğ½§â9°â¾*ÏÜÉù›Ü/;ŠŸ”…\'¥a$ºx]ÑQSº**y6É/OdZ=^M>HÉv¼5£tìºr-9f¯Åâaj28,9Ò+Q¿—gªóEnû\"¢îˆkàW——¼\')3Î¢¶åÉ>qÓôì®Õè–€†hŸ%Y­E]w‚­›I=û1Wm¾ÊA\Zn®Ok5Ö‰ˆ´Vg¼Åb\'ê½±ŒcQŒDk\Z›5©ÙÙ73»ô0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0?ÿÙ',0),(3,'POS',100,NULL,0),(4,'E-COMMERCE',150,NULL,0),(5,'Factura electrÃ³nica',150,NULL,0);

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
SELECT `Producto_id_PRD` FROM productos
;
SELECT `Producto_id_PRUS` FROM `productos_users`
WHERE `User_id_PRUS` = p_user
;  
END */$$
DELIMITER ;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
