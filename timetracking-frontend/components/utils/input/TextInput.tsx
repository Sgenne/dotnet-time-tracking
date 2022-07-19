import { ChangeEventHandler } from "react";
import { getInputChangeHandler } from "../../../utils/adapters/InputElementChangeAdapter";
import TextInputProps from "../../../types/InputProps";
import standardStyles from "../../../styles/utils/input/TextInput.module.css";

export type GenericTextInputProps = TextInputProps & {
  styles: { [key: string]: string };
  hidden?: boolean
};

const TextInput = ({ onChange, value, styles, hidden = false }: GenericTextInputProps) => {
  const changeHandler: ChangeEventHandler<HTMLInputElement> =
    getInputChangeHandler(onChange);

  const inputType = hidden ? "password" : "default";
  const className = `${standardStyles["input"]} ${styles["input"]}`

  return (
    <input className={className} type={inputType} value={value} onChange={changeHandler} />
  );
};

export default TextInput;
