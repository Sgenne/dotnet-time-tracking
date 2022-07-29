import axios, { AxiosResponse } from "axios";
import Result, { resultFromAxiosError } from "../utils/Result";

export const sendGetRequest = async <TApiResponse>(
  url: string,
  config: object = {},
  successMessage: string = ""
): Promise<Result<TApiResponse>> =>
  sendRequest(axios.get, url, {}, config, successMessage);

export const sendPostRequest = async <TApiResponse>(
  url: string,
  data: object,
  config: object = {
    headers: { "content-type": "text/json" },
  },
  successMessage: string = ""
): Promise<Result<TApiResponse>> =>
  sendRequest(axios.post, url, data, config, successMessage);

const sendRequest = async <TApiResponse>(
  requestFunction: (
    url: string,
    data: object,
    config: object
  ) => Promise<AxiosResponse<TApiResponse, any>>,
  url: string,
  data: object,
  config: object = {
    headers: { "content-type": "text/json" },
  },
  successMessage: string = ""
): Promise<Result<TApiResponse>> => {
  let result: AxiosResponse<TApiResponse>;
  try {
    result = await requestFunction(url, data, config);
  } catch (error) {
    return resultFromAxiosError(error);
  }

  return {
    value: result.data,
    status: result.status,
    message: successMessage,
  };
};
