\connect postgres

 -- schooled Schema
CREATE SCHEMA "schooled"
    AUTHORIZATION postgres;

-- registration table
CREATE TABLE "schooled"."registration"
(
    "db_id" bigserial NOT NULL,
    "id" uuid NOT NULL,
    "version" bigint NOT NULL,
    "event_type" CHARACTER VARYING(100) COLLATE pg_catalog."default"  NOT NULL,
    "event" jsonb NOT NULL,
    "timestamp" timestamp with time zone NOT NULL,
    CONSTRAINT "registrationevent_pkey" PRIMARY KEY ("db_id"),
    CONSTRAINT "version_uq" UNIQUE ("id", "version")
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE "schooled"."registration"
    OWNER to postgres;