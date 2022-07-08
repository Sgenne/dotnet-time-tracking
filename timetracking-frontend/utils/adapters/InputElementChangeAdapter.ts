import { ChangeEvent, ChangeEventHandler } from "react";
import OnStringChange from "../../types/OnStringChange";

/**
 * Creates a ChangeEventHandler<HTMLInputElement> using the given function onChange.
 * @param onChange A function that accepts a string value.
 * @returns A ChangeEventHandler<HTMLInputElement> that includes the functionality of the
 * given function onChange.
 */
export const getInputChangeHandler =
  (onChange: OnStringChange): ChangeEventHandler<HTMLInputElement> =>
  (e: ChangeEvent<HTMLInputElement>) =>
    onChange(e.target.value);
