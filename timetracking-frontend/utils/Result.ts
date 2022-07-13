import { getErrorMessage, getErrorStatusCode } from "./ErrorHandling";
import StatusCode from "./StatusCodes";

export default interface Result<T> {
  status: StatusCode;
  message: string;
  value?: T;
}

/**
 * Produces a Result object from a given AxiosError.
 * @param e The AxiosError object.
 * @returns The created Result object.
 */
export const resultFromAxiosError = <T>(e: unknown): Result<T> => {
  const message: string = getErrorMessage(e);
  const status: number = getErrorStatusCode(e);

  return { message, status };
};
