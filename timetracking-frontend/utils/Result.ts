import StatusCode from "./StatusCodes";

export default interface Result<T> {
  status: StatusCode;
  message: string;
  value?: T;
}

/**
 * Creates a Result object indicating success with the given value. Uses default values for message (empty string)
 * and status (StatusCode.OK) if none are given.
 * @param value The resulting value from the performed operation.
 * @param message The optional message describing the outcome of the operation.
 * @param status The optional status code describing the outcome of the operation.
 * @returns A Result object.
 */
export const successResult = <T>(
  value: T,
  message = "",
  status = StatusCode.OK
): Result<T> => ({
  value,
  message,
  status,
});
