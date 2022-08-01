import axios, { AxiosResponse } from "axios";
import Result, { resultFromAxiosError } from "../utils/Result";
import LoginResponse from "../types/apiResponses/LoginResponse";
import { baseUrl, sendPostRequest } from ".";

const baseAuthUrl = `${baseUrl}/auth`;

export const LOGIN_URL = `${baseAuthUrl}/login`;
export const REGISTER_URL = `${baseAuthUrl}/register`;

export const sendLoginRequest = async (username: string, password: string) =>
  sendPostRequest<LoginResponse>({
    url: LOGIN_URL,
    data: { username, password },
  });
