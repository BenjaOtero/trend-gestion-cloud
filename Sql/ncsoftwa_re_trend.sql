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

insert  into `productos`(`Producto_id_PRD`,`Descripcion_PRD`,`Precio_PRD`,`Imagen_PRD`,`Promo_activa_PRD`) values (1,'Gestion FREE',0,'',0),(2,'Gestion PRO',150,'����\0JFIF\0\0H\0H\0\0��\0C\0		\n\n\n\n          ��\0C\r\r\Z\Z                                                 ��\0\0��\0��\0\0\0\0\0\0\0\0\0\0\0\0\0��\07\0\0\0\0\0\0!1A\"Qa2Bq#Rr�$�%34�����\0\0\0\0\0\0\0\0\0\0\0\0\0��\0:\0\0\0\0\0\0!1AQaq��\"#2��R��3Br��$������\0\0\0?\0��\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0K����S�����Fd�����]���;vO*��r��?�:��v��fY�\\T�kO��\'\\G��Rӓ �?�o����\0�,l�o�\0ې�z����6tcW����\r���;�y{~�?!�u��K����J�S]�꜒;ۺ5������{�Ͱͣ���p\n��8�[����\'ֿ&��Γ���A���L��-�/��Y���6��ۛa�Rb7��A�����.IǊ�Zv����\Z�pi�c��6�x�J�vjY7W�ȬO�rGo�s\Z�_%�T�#����rf��h�������޵Ҙ:�X������U\\���k��;�س|��yqt�+S���:M����>�؍S��8�28��Z����_��7^m_����C4�[F�=�xv|��Vki���!�՞�1bE�V�w��\\��|ʈ��؋혿��ٽ|��V���������)r�0㸣�Ӟ�M��������I����g7�.\\�k3M��}/��j	��C9R��$s�b+\"7Ю���s��u��]&~}��������ƚ+Ɋ��G[Ϝ�f!Ћ�.�5�7�X�A��W\"e|fBX;ѐ���nJ�\'��)iuh���^��p�bɊ�+;���Y�SX��h,��c�栖ܫ�(��9��5��j*��\"�%���h��~���n\Zs�����Z:;�p����]�[J�������w�ҙ+n�V�Z,�6�+5���ŏ՚k!������\\}G+l��LV�9y9�\'dT1\\՘�\'�7��u�F;Rb��r���#Cf/�?��{���~f+�=��\Z�_�Қ�v��z��x�9�c�W���ٓ9�\r���l�U-5���ܕ�]�vj(ɩ�\'i��N��W�&��x��C��-��6�M��|�s�zn��j+��쪂ڬu�=�i��4�)�g�v����KRP��.e�������/�b�ɶ������P[,M9�1�c���Uś�w���~\r{\Z��DW�䲕lؒ�:J��V��x7��_�vC�+�y���INl��Ŏ��b�c��7��5z]�����s��d^Vc��Ɛ5+x���ʞ|\Zi2�W���ht�͵1[?-����|�6���ʪ�>r�\\׬Nbrs���Z����6�^(�C���u�b�m�:\n9\Zq]�;,ԝ9E<NG5��T��+h��;9Y��������T���A���	e�l_�ʯ��T���������mH�_9zf8~\rNL�4sV����G�D����Y��4�qPo�=9)6tm��9��d���_����ܵ����e�>\r���D��է����Y�1��L�&���ԉ�8=8�\0RwD]���d��ܜ�9��.�u3�����m3]����][�8i3�gh�SV-��Tl��F&���{��٧>:�sD�{�p�|/[�0F+㵻O6�[��OR����i���P�c��S�\0ӂ)�Y$�m���W�e�.�v�W�]S�p\ZM�_Qm�i�bv�i��h���W)K�8<k�\r��;�Vkx�S�&�����^�D�Ʒ�zG74[ݲm>^���xV���/�3�����uM=Q�jf�5ce�_R�����*��eN�c%y���>�<��n�y�ǔ��\\�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0��|�e�f����f##��ț�I�ݾ�\n��9��KyD������S���2c��.o��O���\\��D��g��|��p��~6/����<�i�NO�y��m���p�+d�Ӯ��1c���4��Smؒ+�S��Ϳ�ǧ\\Y-�2�>�b����X�}?�o�[�w��C��2V�پ�Ƭ����7.[��{x7�S쿾���:�㼻�ni���6�����cPt��Z�6j���F��M��oS+��ţ{b�Ѷ����\'���=�g���\Z��\\s1c���~�h�e&X�G\Z�\0�l_������ŧQ;r�M�\0���)���I������}��Ϳ��74�-��:�{�p�Y�����؇N�_Ū�V)\Z����x�o�������\Z�^,�\\J��X�N_��?�����8,;��[o��M��;���p�R5����\Za�_�L�V8��,q�u�X�F����Dj�&�/��wT��d�\0��64�ÿE���؋&���=���QJ�5�����s��~]��,ޝխ��b�bΙ�]���P[P�a�棡��r96�Q;y�ܟ&;��m����^�]��.zb�NZMg~nI��^��z����>z����R���5E�g�.��FJ�9OÓyH�\rDb��­�����ճ�ϓ]���RcO���=7���\'PY��K&_��F˰�\n�U]m\Z�M�r|��{x��Χ����_.�8,��3�W˖y\'�m���\0��I�|�������c��Ċ���������+��Od��̿�.l�\r��?W��v�8��Mi��[�1�v��k<�?�9�D��n�3�yn��;*6^���E��P�|sM=c�z�+Y]O�~�����b:o������Փa1��O���k��y\Zkn�v����N+��}���,o���z��<CM\\׌q��i�歹\'�o|�D�c�^�@=��ǥ�l�\\�s9��*��ԗ�\'S��\\�\0\Z��ܙ��m������?}�M�d4m�e��u#�\Z�\0.&����Z�����Mrc�g�;v��-m?��M]rW�yrV{��=|�|��:�S7M5�.+pyr�\0�+C+���=��L��#vX�8���J�<+�ܳֳi�W�irNO���1������V�2\Z��wL���$�c��/x�k������?�v5�D�[�/�QkSK��.�<i�n��?��VKU���B�وka[8�W3;5��Uj��U���)bb#U��\\�w�Ny�ח$ro�o��V�H0X{��eb�8�K-�5��X�_Iˊo�7v�,u�����k2�&�+i��Vzz��\0�r��UUFٝ\Z�D�o��7�/������j��A2I1:y���H��Md���Uc�v�cN%ڿ�X�.b2���\0�$r-�Yz�\0�֗nc^��Վ`戻�n��t$����k�®hp`�>5+��w��^�^�N����K��4��y�/bkx\"+\\����U��1�::�Y?d��E�v���=�z�M\\���L��-��\Z����;�ћ�����O~ȋ���Ǩ�4�s��\Z���U�$i��ë�t�#�{�?���3R�uwHg��ZN��e6�bvң�|�nӷ���bl��K�m��[�8^�o9���s�񟛤��/����+R��\02��]�k�WxD/������Z<��ю�<�?O�L�6�.�Wu��~2yl����f��\r��*���b���y�_<��D�r���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0��\nY\nrһ,ԝ�f�D��\'�ūOd�s_���������=�\Z����%�7������\0e?�b�|^��ݮ��6�sr��e�9���~���T�zZ/�#O��;m�6�Y�/���]���x�ĉ�y��U���Af[JW��FԒy_�?S��]�ۿ���A��ڿ���Vc�7�>X���zNj��\\�OIh*�I�z��r�tEo�ʄ���������g>��Ø���cx��\0M4�y)��y�6*�����F��:D_���ɥ�����.=��srLr�w��D���˧zy�4�[pc��]}�˶${��Dv���˺y�3�MJv�i��z�M�9-�;DF�&zZ\'OR�i��9�yY$o�dz��ʪ�\0�W�}��k��NO$yx�|���Z6�yv��k@�Kzj\r7j�M�����s�͛xsdߚ/;��=&��tm���i��Em�Kw���40(јL�y:��z�ZkR�oI�pG|���n�Ƙ�x�;���}���1�;LE\'�V\"7���	T^���a�a�I]G!c�,5dz����;}ڿ�[��f�t�k����k���Ҽ��;zO�6>�����u��h��EbK3,���\0+Z��٩��O�b��ݽ��Oi�D�Ecn��q��S��+�,ձ����EHU�vr���*��t� ˦�O�����5�����m���%��|f_6;%]�iN�e����eEOeN�KzE�i죦�d�xɎyoj�7�\Z����V[QyT���KK��\0+v��ܭ]8�����krRk���b\"&~kt�����\"_���77m�v��~>�Bo���n\\��g�>�\0���{�(�M�M\'��,�ނH�,o��+�Z��w�|��sL�Z^w��z=���ä���b&(��IQӖ��j|1׿�>wz����M�{}L�MH�.�%�n9�ɞ��o�N�:G˳�W��G+����O�Lk��rK\"\"|�o��7�����b���q�V��K}��n�\'�ɥ�}������Ww���=���fro�ܜ����s8t��ۻ^#Ƶ:��䟻^��6�:G��v�6EBW�i�)$M��2�ݾ���֛��Y��j-[d�摴t�M5�p�o��LK\r6��#�=y?�w*��X�H�;5�����x�g{}u����Ǖ�em)�f���J��o��L5�&t<G6�m8�nh�~	rUFSJ�ry�n^�J�ؕs�H�sQ���ݨ�/�r+᭭���9��*������/;����\'�a$��x]�QS�**y6Ɏ/OdZ=^M>HɎv�5�t�r-9f���aj28,9�+Q��g��En�\"��k�W���\'�)�3΢���>q����薀�h�%Y�E]w���I=�1Wm��A\Zn�Ok5։��Vg��b\'꽱�cQ�Dk\Z�5����73��0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0?��',0),(3,'POS',100,NULL,0),(4,'E-COMMERCE',150,NULL,0),(5,'Factura electrónica',150,NULL,0);

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
