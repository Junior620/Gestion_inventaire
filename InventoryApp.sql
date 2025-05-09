PGDMP  	    ,                }            InventoryApp    17.4    17.4 M    �           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                           false            �           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                           false            �           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                           false            �           1262    24901    InventoryApp    DATABASE     t   CREATE DATABASE "InventoryApp" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'fr-FR';
    DROP DATABASE "InventoryApp";
                     postgres    false                        2615    2200    public    SCHEMA        CREATE SCHEMA public;
    DROP SCHEMA public;
                     pg_database_owner    false            �           0    0    SCHEMA public    COMMENT     6   COMMENT ON SCHEMA public IS 'standard public schema';
                        pg_database_owner    false    4            �            1259    24970 	   commandes    TABLE     V  CREATE TABLE public.commandes (
    id integer NOT NULL,
    fournisseurid integer,
    datecommande timestamp without time zone DEFAULT CURRENT_TIMESTAMP,
    type character varying(10) NOT NULL,
    CONSTRAINT commandes_type_check CHECK (((type)::text = ANY ((ARRAY['entrée'::character varying, 'sortie'::character varying])::text[])))
);
    DROP TABLE public.commandes;
       public         heap r       postgres    false    4            �            1259    24969    commandes_id_seq    SEQUENCE     �   CREATE SEQUENCE public.commandes_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 '   DROP SEQUENCE public.commandes_id_seq;
       public               postgres    false    226    4            �           0    0    commandes_id_seq    SEQUENCE OWNED BY     E   ALTER SEQUENCE public.commandes_id_seq OWNED BY public.commandes.id;
          public               postgres    false    225            �            1259    24984    commandesproduits    TABLE     �   CREATE TABLE public.commandesproduits (
    id integer NOT NULL,
    commandeid integer,
    produitid integer,
    quantite integer NOT NULL
);
 %   DROP TABLE public.commandesproduits;
       public         heap r       postgres    false    4            �            1259    24983    commandesproduits_id_seq    SEQUENCE     �   CREATE SEQUENCE public.commandesproduits_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 /   DROP SEQUENCE public.commandesproduits_id_seq;
       public               postgres    false    228    4            �           0    0    commandesproduits_id_seq    SEQUENCE OWNED BY     U   ALTER SEQUENCE public.commandesproduits_id_seq OWNED BY public.commandesproduits.id;
          public               postgres    false    227            �            1259    24961    fournisseurs    TABLE     �   CREATE TABLE public.fournisseurs (
    id integer NOT NULL,
    nom character varying(100) NOT NULL,
    telephone character varying(20),
    email character varying(100),
    adresse text
);
     DROP TABLE public.fournisseurs;
       public         heap r       postgres    false    4            �            1259    24960    fournisseurs_id_seq    SEQUENCE     �   CREATE SEQUENCE public.fournisseurs_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 *   DROP SEQUENCE public.fournisseurs_id_seq;
       public               postgres    false    224    4            �           0    0    fournisseurs_id_seq    SEQUENCE OWNED BY     K   ALTER SEQUENCE public.fournisseurs_id_seq OWNED BY public.fournisseurs.id;
          public               postgres    false    223            �            1259    49153    historiqueactions    TABLE     [  CREATE TABLE public.historiqueactions (
    id integer NOT NULL,
    date timestamp without time zone DEFAULT CURRENT_TIMESTAMP,
    action text NOT NULL,
    produit text NOT NULL,
    quantite integer NOT NULL,
    CONSTRAINT historiqueactions_action_check CHECK ((action = ANY (ARRAY['Ajouter'::text, 'Modifier'::text, 'Supprimer'::text])))
);
 %   DROP TABLE public.historiqueactions;
       public         heap r       postgres    false    4            �            1259    49152    historiqueactions_id_seq    SEQUENCE     �   CREATE SEQUENCE public.historiqueactions_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 /   DROP SEQUENCE public.historiqueactions_id_seq;
       public               postgres    false    232    4            �           0    0    historiqueactions_id_seq    SEQUENCE OWNED BY     U   ALTER SEQUENCE public.historiqueactions_id_seq OWNED BY public.historiqueactions.id;
          public               postgres    false    231            �            1259    24926    mouvementsstock    TABLE     �  CREATE TABLE public.mouvementsstock (
    id integer NOT NULL,
    produitid integer,
    type character varying(10),
    quantiteenstock integer NOT NULL,
    dateoperation timestamp without time zone DEFAULT CURRENT_TIMESTAMP,
    utilisateurid integer,
    remarque text,
    CONSTRAINT mouvementsstock_type_check CHECK (((type)::text = ANY ((ARRAY['ENTREE'::character varying, 'SORTIE'::character varying])::text[])))
);
 #   DROP TABLE public.mouvementsstock;
       public         heap r       postgres    false    4            �            1259    24925    mouvementsstock_id_seq    SEQUENCE     �   CREATE SEQUENCE public.mouvementsstock_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 -   DROP SEQUENCE public.mouvementsstock_id_seq;
       public               postgres    false    4    222            �           0    0    mouvementsstock_id_seq    SEQUENCE OWNED BY     Q   ALTER SEQUENCE public.mouvementsstock_id_seq OWNED BY public.mouvementsstock.id;
          public               postgres    false    221            �            1259    49164    notifications    TABLE     �  CREATE TABLE public.notifications (
    id integer NOT NULL,
    produitid integer,
    message text NOT NULL,
    dateheure timestamp without time zone DEFAULT CURRENT_TIMESTAMP,
    typenotification character varying(50),
    statut character varying(10) DEFAULT 'Non lue'::character varying,
    supprimee boolean DEFAULT false,
    CONSTRAINT notifications_statut_check CHECK (((statut)::text = ANY ((ARRAY['Lue'::character varying, 'Non lue'::character varying])::text[]))),
    CONSTRAINT notifications_typenotification_check CHECK (((typenotification)::text = ANY ((ARRAY['Stock faible'::character varying, 'Réapprovisionnement'::character varying])::text[])))
);
 !   DROP TABLE public.notifications;
       public         heap r       postgres    false    4            �            1259    49163    notifications_id_seq    SEQUENCE     �   CREATE SEQUENCE public.notifications_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 +   DROP SEQUENCE public.notifications_id_seq;
       public               postgres    false    234    4            �           0    0    notifications_id_seq    SEQUENCE OWNED BY     M   ALTER SEQUENCE public.notifications_id_seq OWNED BY public.notifications.id;
          public               postgres    false    233            �            1259    24915    produits    TABLE     .  CREATE TABLE public.produits (
    id integer NOT NULL,
    nom character varying(100) NOT NULL,
    categorie text,
    prixunitaire numeric(10,2) NOT NULL,
    quantiteenstock integer NOT NULL,
    seuilalerte integer DEFAULT 0,
    dateajout timestamp without time zone DEFAULT CURRENT_TIMESTAMP
);
    DROP TABLE public.produits;
       public         heap r       postgres    false    4            �            1259    24914    produits_id_seq    SEQUENCE     �   CREATE SEQUENCE public.produits_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 &   DROP SEQUENCE public.produits_id_seq;
       public               postgres    false    220    4            �           0    0    produits_id_seq    SEQUENCE OWNED BY     C   ALTER SEQUENCE public.produits_id_seq OWNED BY public.produits.id;
          public               postgres    false    219            �            1259    25001    sessionutilisateurs    TABLE     �  CREATE TABLE public.sessionutilisateurs (
    id integer NOT NULL,
    utilisateurid integer NOT NULL,
    heureconnexion timestamp without time zone DEFAULT CURRENT_TIMESTAMP,
    heuredeconnexion timestamp without time zone,
    dureesession interval GENERATED ALWAYS AS ((heuredeconnexion - heureconnexion)) STORED,
    adresseip character varying(100),
    navigateur character varying(255)
);
 '   DROP TABLE public.sessionutilisateurs;
       public         heap r       postgres    false    4            �            1259    25000    sessionutilisateurs_id_seq    SEQUENCE     �   CREATE SEQUENCE public.sessionutilisateurs_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 1   DROP SEQUENCE public.sessionutilisateurs_id_seq;
       public               postgres    false    4    230            �           0    0    sessionutilisateurs_id_seq    SEQUENCE OWNED BY     Y   ALTER SEQUENCE public.sessionutilisateurs_id_seq OWNED BY public.sessionutilisateurs.id;
          public               postgres    false    229            �            1259    24903    utilisateurs    TABLE     !  CREATE TABLE public.utilisateurs (
    id integer NOT NULL,
    nom character varying(100),
    email character varying(100) NOT NULL,
    motdepasse character varying(255) NOT NULL,
    role character varying(50),
    datecreation timestamp without time zone DEFAULT CURRENT_TIMESTAMP
);
     DROP TABLE public.utilisateurs;
       public         heap r       postgres    false    4            �            1259    24902    utilisateurs_id_seq    SEQUENCE     �   CREATE SEQUENCE public.utilisateurs_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 *   DROP SEQUENCE public.utilisateurs_id_seq;
       public               postgres    false    218    4            �           0    0    utilisateurs_id_seq    SEQUENCE OWNED BY     K   ALTER SEQUENCE public.utilisateurs_id_seq OWNED BY public.utilisateurs.id;
          public               postgres    false    217            �           2604    24973    commandes id    DEFAULT     l   ALTER TABLE ONLY public.commandes ALTER COLUMN id SET DEFAULT nextval('public.commandes_id_seq'::regclass);
 ;   ALTER TABLE public.commandes ALTER COLUMN id DROP DEFAULT;
       public               postgres    false    225    226    226            �           2604    24987    commandesproduits id    DEFAULT     |   ALTER TABLE ONLY public.commandesproduits ALTER COLUMN id SET DEFAULT nextval('public.commandesproduits_id_seq'::regclass);
 C   ALTER TABLE public.commandesproduits ALTER COLUMN id DROP DEFAULT;
       public               postgres    false    228    227    228            �           2604    24964    fournisseurs id    DEFAULT     r   ALTER TABLE ONLY public.fournisseurs ALTER COLUMN id SET DEFAULT nextval('public.fournisseurs_id_seq'::regclass);
 >   ALTER TABLE public.fournisseurs ALTER COLUMN id DROP DEFAULT;
       public               postgres    false    224    223    224            �           2604    49156    historiqueactions id    DEFAULT     |   ALTER TABLE ONLY public.historiqueactions ALTER COLUMN id SET DEFAULT nextval('public.historiqueactions_id_seq'::regclass);
 C   ALTER TABLE public.historiqueactions ALTER COLUMN id DROP DEFAULT;
       public               postgres    false    231    232    232            �           2604    24929    mouvementsstock id    DEFAULT     x   ALTER TABLE ONLY public.mouvementsstock ALTER COLUMN id SET DEFAULT nextval('public.mouvementsstock_id_seq'::regclass);
 A   ALTER TABLE public.mouvementsstock ALTER COLUMN id DROP DEFAULT;
       public               postgres    false    222    221    222            �           2604    49167    notifications id    DEFAULT     t   ALTER TABLE ONLY public.notifications ALTER COLUMN id SET DEFAULT nextval('public.notifications_id_seq'::regclass);
 ?   ALTER TABLE public.notifications ALTER COLUMN id DROP DEFAULT;
       public               postgres    false    234    233    234            �           2604    24918    produits id    DEFAULT     j   ALTER TABLE ONLY public.produits ALTER COLUMN id SET DEFAULT nextval('public.produits_id_seq'::regclass);
 :   ALTER TABLE public.produits ALTER COLUMN id DROP DEFAULT;
       public               postgres    false    219    220    220            �           2604    25004    sessionutilisateurs id    DEFAULT     �   ALTER TABLE ONLY public.sessionutilisateurs ALTER COLUMN id SET DEFAULT nextval('public.sessionutilisateurs_id_seq'::regclass);
 E   ALTER TABLE public.sessionutilisateurs ALTER COLUMN id DROP DEFAULT;
       public               postgres    false    229    230    230            �           2604    24906    utilisateurs id    DEFAULT     r   ALTER TABLE ONLY public.utilisateurs ALTER COLUMN id SET DEFAULT nextval('public.utilisateurs_id_seq'::regclass);
 >   ALTER TABLE public.utilisateurs ALTER COLUMN id DROP DEFAULT;
       public               postgres    false    217    218    218            |          0    24970 	   commandes 
   TABLE DATA           J   COPY public.commandes (id, fournisseurid, datecommande, type) FROM stdin;
    public               postgres    false    226   �b       ~          0    24984    commandesproduits 
   TABLE DATA           P   COPY public.commandesproduits (id, commandeid, produitid, quantite) FROM stdin;
    public               postgres    false    228   �b       z          0    24961    fournisseurs 
   TABLE DATA           J   COPY public.fournisseurs (id, nom, telephone, email, adresse) FROM stdin;
    public               postgres    false    224   c       �          0    49153    historiqueactions 
   TABLE DATA           P   COPY public.historiqueactions (id, date, action, produit, quantite) FROM stdin;
    public               postgres    false    232   "c       x          0    24926    mouvementsstock 
   TABLE DATA           w   COPY public.mouvementsstock (id, produitid, type, quantiteenstock, dateoperation, utilisateurid, remarque) FROM stdin;
    public               postgres    false    222   �c       �          0    49164    notifications 
   TABLE DATA           o   COPY public.notifications (id, produitid, message, dateheure, typenotification, statut, supprimee) FROM stdin;
    public               postgres    false    234   �d       v          0    24915    produits 
   TABLE DATA           m   COPY public.produits (id, nom, categorie, prixunitaire, quantiteenstock, seuilalerte, dateajout) FROM stdin;
    public               postgres    false    220   �f       �          0    25001    sessionutilisateurs 
   TABLE DATA           y   COPY public.sessionutilisateurs (id, utilisateurid, heureconnexion, heuredeconnexion, adresseip, navigateur) FROM stdin;
    public               postgres    false    230   �h       t          0    24903    utilisateurs 
   TABLE DATA           V   COPY public.utilisateurs (id, nom, email, motdepasse, role, datecreation) FROM stdin;
    public               postgres    false    218   j       �           0    0    commandes_id_seq    SEQUENCE SET     ?   SELECT pg_catalog.setval('public.commandes_id_seq', 1, false);
          public               postgres    false    225            �           0    0    commandesproduits_id_seq    SEQUENCE SET     G   SELECT pg_catalog.setval('public.commandesproduits_id_seq', 1, false);
          public               postgres    false    227            �           0    0    fournisseurs_id_seq    SEQUENCE SET     B   SELECT pg_catalog.setval('public.fournisseurs_id_seq', 1, false);
          public               postgres    false    223            �           0    0    historiqueactions_id_seq    SEQUENCE SET     F   SELECT pg_catalog.setval('public.historiqueactions_id_seq', 2, true);
          public               postgres    false    231            �           0    0    mouvementsstock_id_seq    SEQUENCE SET     F   SELECT pg_catalog.setval('public.mouvementsstock_id_seq', 102, true);
          public               postgres    false    221            �           0    0    notifications_id_seq    SEQUENCE SET     C   SELECT pg_catalog.setval('public.notifications_id_seq', 29, true);
          public               postgres    false    233            �           0    0    produits_id_seq    SEQUENCE SET     >   SELECT pg_catalog.setval('public.produits_id_seq', 29, true);
          public               postgres    false    219            �           0    0    sessionutilisateurs_id_seq    SEQUENCE SET     I   SELECT pg_catalog.setval('public.sessionutilisateurs_id_seq', 16, true);
          public               postgres    false    229            �           0    0    utilisateurs_id_seq    SEQUENCE SET     A   SELECT pg_catalog.setval('public.utilisateurs_id_seq', 3, true);
          public               postgres    false    217            �           2606    24977    commandes commandes_pkey 
   CONSTRAINT     V   ALTER TABLE ONLY public.commandes
    ADD CONSTRAINT commandes_pkey PRIMARY KEY (id);
 B   ALTER TABLE ONLY public.commandes DROP CONSTRAINT commandes_pkey;
       public                 postgres    false    226            �           2606    24989 (   commandesproduits commandesproduits_pkey 
   CONSTRAINT     f   ALTER TABLE ONLY public.commandesproduits
    ADD CONSTRAINT commandesproduits_pkey PRIMARY KEY (id);
 R   ALTER TABLE ONLY public.commandesproduits DROP CONSTRAINT commandesproduits_pkey;
       public                 postgres    false    228            �           2606    24968    fournisseurs fournisseurs_pkey 
   CONSTRAINT     \   ALTER TABLE ONLY public.fournisseurs
    ADD CONSTRAINT fournisseurs_pkey PRIMARY KEY (id);
 H   ALTER TABLE ONLY public.fournisseurs DROP CONSTRAINT fournisseurs_pkey;
       public                 postgres    false    224            �           2606    49162 (   historiqueactions historiqueactions_pkey 
   CONSTRAINT     f   ALTER TABLE ONLY public.historiqueactions
    ADD CONSTRAINT historiqueactions_pkey PRIMARY KEY (id);
 R   ALTER TABLE ONLY public.historiqueactions DROP CONSTRAINT historiqueactions_pkey;
       public                 postgres    false    232            �           2606    24933 $   mouvementsstock mouvementsstock_pkey 
   CONSTRAINT     b   ALTER TABLE ONLY public.mouvementsstock
    ADD CONSTRAINT mouvementsstock_pkey PRIMARY KEY (id);
 N   ALTER TABLE ONLY public.mouvementsstock DROP CONSTRAINT mouvementsstock_pkey;
       public                 postgres    false    222            �           2606    49175     notifications notifications_pkey 
   CONSTRAINT     ^   ALTER TABLE ONLY public.notifications
    ADD CONSTRAINT notifications_pkey PRIMARY KEY (id);
 J   ALTER TABLE ONLY public.notifications DROP CONSTRAINT notifications_pkey;
       public                 postgres    false    234            �           2606    24924    produits produits_pkey 
   CONSTRAINT     T   ALTER TABLE ONLY public.produits
    ADD CONSTRAINT produits_pkey PRIMARY KEY (id);
 @   ALTER TABLE ONLY public.produits DROP CONSTRAINT produits_pkey;
       public                 postgres    false    220            �           2606    25008 ,   sessionutilisateurs sessionutilisateurs_pkey 
   CONSTRAINT     j   ALTER TABLE ONLY public.sessionutilisateurs
    ADD CONSTRAINT sessionutilisateurs_pkey PRIMARY KEY (id);
 V   ALTER TABLE ONLY public.sessionutilisateurs DROP CONSTRAINT sessionutilisateurs_pkey;
       public                 postgres    false    230            �           2606    24913 #   utilisateurs utilisateurs_email_key 
   CONSTRAINT     _   ALTER TABLE ONLY public.utilisateurs
    ADD CONSTRAINT utilisateurs_email_key UNIQUE (email);
 M   ALTER TABLE ONLY public.utilisateurs DROP CONSTRAINT utilisateurs_email_key;
       public                 postgres    false    218            �           2606    24911    utilisateurs utilisateurs_pkey 
   CONSTRAINT     \   ALTER TABLE ONLY public.utilisateurs
    ADD CONSTRAINT utilisateurs_pkey PRIMARY KEY (id);
 H   ALTER TABLE ONLY public.utilisateurs DROP CONSTRAINT utilisateurs_pkey;
       public                 postgres    false    218            �           2606    24978 &   commandes commandes_fournisseurid_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.commandes
    ADD CONSTRAINT commandes_fournisseurid_fkey FOREIGN KEY (fournisseurid) REFERENCES public.fournisseurs(id) ON DELETE SET NULL;
 P   ALTER TABLE ONLY public.commandes DROP CONSTRAINT commandes_fournisseurid_fkey;
       public               postgres    false    224    226    4816            �           2606    24990 3   commandesproduits commandesproduits_commandeid_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.commandesproduits
    ADD CONSTRAINT commandesproduits_commandeid_fkey FOREIGN KEY (commandeid) REFERENCES public.commandes(id) ON DELETE CASCADE;
 ]   ALTER TABLE ONLY public.commandesproduits DROP CONSTRAINT commandesproduits_commandeid_fkey;
       public               postgres    false    4818    228    226            �           2606    24995 2   commandesproduits commandesproduits_produitid_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.commandesproduits
    ADD CONSTRAINT commandesproduits_produitid_fkey FOREIGN KEY (produitid) REFERENCES public.produits(id) ON DELETE CASCADE;
 \   ALTER TABLE ONLY public.commandesproduits DROP CONSTRAINT commandesproduits_produitid_fkey;
       public               postgres    false    228    220    4812            �           2606    25009 "   sessionutilisateurs fk_utilisateur    FK CONSTRAINT     �   ALTER TABLE ONLY public.sessionutilisateurs
    ADD CONSTRAINT fk_utilisateur FOREIGN KEY (utilisateurid) REFERENCES public.utilisateurs(id) ON DELETE CASCADE;
 L   ALTER TABLE ONLY public.sessionutilisateurs DROP CONSTRAINT fk_utilisateur;
       public               postgres    false    218    230    4810            �           2606    24934 .   mouvementsstock mouvementsstock_produitid_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.mouvementsstock
    ADD CONSTRAINT mouvementsstock_produitid_fkey FOREIGN KEY (produitid) REFERENCES public.produits(id) ON DELETE CASCADE;
 X   ALTER TABLE ONLY public.mouvementsstock DROP CONSTRAINT mouvementsstock_produitid_fkey;
       public               postgres    false    4812    222    220            �           2606    24939 2   mouvementsstock mouvementsstock_utilisateurid_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.mouvementsstock
    ADD CONSTRAINT mouvementsstock_utilisateurid_fkey FOREIGN KEY (utilisateurid) REFERENCES public.utilisateurs(id) ON DELETE SET NULL;
 \   ALTER TABLE ONLY public.mouvementsstock DROP CONSTRAINT mouvementsstock_utilisateurid_fkey;
       public               postgres    false    218    222    4810            �           2606    49176 *   notifications notifications_produitid_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.notifications
    ADD CONSTRAINT notifications_produitid_fkey FOREIGN KEY (produitid) REFERENCES public.produits(id) ON DELETE CASCADE;
 T   ALTER TABLE ONLY public.notifications DROP CONSTRAINT notifications_produitid_fkey;
       public               postgres    false    220    234    4812            |      x������ � �      ~      x������ � �      z      x������ � �      �   a   x�3�4202�50�52R04�25�2�Գ0624��t��/-I-�L� ��2BQjje`deh�gf`bj`�雟���	T�X�Z������Z�ib����� ��      x   X  x����R�@Ek�W��h�XI�S����c`��&�>�I6&�]����}�q�awx��⁐t��#�A+���Ad><�Ǘc���X� m M,Ot�� !DkHd  V��n ڔk�@� U��`��^L���܁X*�r�@�6�@E�)�j�	0�*{�F�6�����cѴ^�}J��)Ω���U5#0c�vR�:7!�MN�6Ț���q=��v��e�Aī�r��r��p��c�6G��r|~+�xAt:��T~kf�"��ԑuTEu��I���_r�6ZI�cybQq�f҉�S�Qɇ�?hS�!�y�?_��<�Ϗ���/TP�.      �   �  x�͖=n�0���)�!8��ԥ����4r�,�+Ɏ~�\#H ���Bg]laaIPAH���
������׏+�ø}���e�ix�p�o��q]����@7��:|��n��ߟ������4��e�75�u݈
�n�:0\�+���Bn҅L*�y�v��m����y��D8`�F��s�,�g���@�VՒlā���#��b���b�ז}	��#�a�C��z�4e���;��"d��7��K�x�'�ttY!UA�i%D���I�����n=S��'�G&�|\dYn��G��3#%�.�3K\ۣpYZs�h�W�E��_.�����ӄs��O��&AD\:�Nd'�/O���`��T�#��"�p2����ϔ<Kx8}*Y4�(I���T`�OS�X.g�`SZ��&b���m��j���?,�2+͜~�l�Z}�|��      v     x���Mn�@�לS��r~�k
4@�]u�ؓTEl���EO_JF+j
Ðw��#9�������P�þ�}� ��Y/Q.�.�4�g/��K����{��o���p��cn$7A|,4rn�×�����U#��KD�� E�Y������R|��
�)UG��q�6�v_w�q���g�A0&�����3}��9;
�[��ժ�v}7����K��#������!�s�"���̖${.��8�P�9B��Jp�Fk焠ɧ�Yyd����ט����:':�����r`<_�6#��R�����/V�@E�hO��(5}��)9f�nG����6�Q����!�)S�`.cD�l&�e/��7c�
l9��k��~������K^b+�u��e�p����v�]t*���9�e:B�q���s��o�`��҅��u�_3�G&,!;z���Fu�����_bKPC���$b`�۟o�p��x9+��_�?u��}h׶w�t��B]l6���c�]?�a=���NG3���'1�����ݽC`      �   �   x���1N1�:s�\`"�;��t+����@4ہ��ّX$�O� �R���l��8�PV�+8�;I�%n�P��������6<�_?����_Η����O�&$Q�3���>K�V�h)�,�>+O�1b�?IM&�:j�}��		P4���3KJ��ҿ"�.�ɤ�7�6��;�UЋ��5�YLS,�9��y����$�J͉a�%vb��!�\��9�<�Tř%� �X��c[���x;�3,���e��,�7�}+�      t   �   x���A
�0����)r���&IS�ҭ�ܔZk�M ��W܈�B���'T�:ך�-������O��B [0��1o�o�5�l#ش"�9:��^h-�m.i�����?��h_�L��C���#�R�����"#�5��W'��z�/<     