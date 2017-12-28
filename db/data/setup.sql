\connect postgres

 -- schooled Schema
CREATE SCHEMA "schooled"
    AUTHORIZATION postgres;

-- course table
CREATE TABLE "schooled"."course"
(
    "db_id" bigserial NOT NULL,
    "id" uuid NOT NULL,
    "content" jsonb NOT NULL,
    "timestamp" timestamp with time zone NOT NULL
    -- "Version" bigint NOT NULL,
    -- "MessageType" character varying(100) COLLATE pg_catalog."default" NOT NULL,
    -- "SerializedMessage" json NOT NULL,
    -- CONSTRAINT "OrderEvent_pkey" PRIMARY KEY ("dbId"),
    -- CONSTRAINT "UniqueIdVersion" UNIQUE ("Id", "Version")
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE "schooled"."course"
    OWNER to postgres;

-- registration table
CREATE TABLE "schooled"."registration"
(
    "db_id" bigserial NOT NULL,
    "id" uuid NOT NULL,
    "content" jsonb NOT NULL,
    "timestamp" timestamp with time zone NOT NULL
    -- "Version" bigint NOT NULL,
    -- "MessageType" character varying(100) COLLATE pg_catalog."default" NOT NULL,
    -- "SerializedMessage" json NOT NULL,
    -- CONSTRAINT "OrderEvent_pkey" PRIMARY KEY ("dbId"),
    -- CONSTRAINT "UniqueIdVersion" UNIQUE ("Id", "Version")
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE "schooled"."registration"
    OWNER to postgres;