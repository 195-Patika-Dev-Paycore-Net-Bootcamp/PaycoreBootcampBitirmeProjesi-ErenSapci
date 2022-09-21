CREATE DATABASE bootcampfinalprojectdb WITH ENCODING = 'UTF8';

CREATE TABLE public.category (
    id integer NOT NULL,
    categoryname character varying(150)
);


ALTER TABLE public.category OWNER TO postgres;

CREATE TABLE public.mail (
    id integer NOT NULL,
    subject character varying(500) NOT NULL,
    content character varying(500) NOT NULL,
    "to" character varying(200) NOT NULL,
    "from" character varying(200) NOT NULL,
    attempt integer NOT NULL,
    status character varying(200)
);


ALTER TABLE public.mail OWNER TO postgres;

CREATE TABLE public.offer (
    id integer NOT NULL,
    userid integer NOT NULL,
    useroffer numeric(19,2) NOT NULL,
    offerstatus character varying(20) NOT NULL,
    productid integer NOT NULL
);


ALTER TABLE public.offer OWNER TO postgres;

CREATE TABLE public.product (
    id integer NOT NULL,
    productname character varying(150) NOT NULL,
    brandname character varying(150) NOT NULL,
    colour character varying(150) NOT NULL,
    price numeric(19,5) NOT NULL,
    isofferable boolean NOT NULL,
    issold boolean NOT NULL,
    categoryid integer NOT NULL,
    ownerid integer NOT NULL,
    description character varying(500)
);


ALTER TABLE public.product OWNER TO postgres;

CREATE TABLE public."user" (
    id integer NOT NULL,
    email character varying(200),
    password character varying(200),
    name character varying(50),
    lastname character varying(150)
);


ALTER TABLE public."user" OWNER TO postgres;

ALTER TABLE ONLY public.category
    ADD CONSTRAINT category_pkey PRIMARY KEY (id);

ALTER TABLE ONLY public.mail
    ADD CONSTRAINT mail_pkey PRIMARY KEY (id);

ALTER TABLE ONLY public.offer
    ADD CONSTRAINT offer_pkey PRIMARY KEY (id);

ALTER TABLE ONLY public.product
    ADD CONSTRAINT product_pkey PRIMARY KEY (id);

ALTER TABLE ONLY public."user"
    ADD CONSTRAINT user_pkey PRIMARY KEY (id);

