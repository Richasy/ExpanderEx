# ExpanderEx

Encapsulation based on the Expander of WinUI 2.6.

Support different degrees of customization, you can run Sample App to view after Clone repository.

## Introduce

The entire `ExpanderEx` component provides multiple controls for free combination.

- **ExpanderEx**: The top-level container, built-in `Expander` and `ExpanderExQuadratePanel`, switch the display of the two according to whether there is *ExpanderEx.Content*.

- **ExpanderExQuadratePanel**: It has the same style of `Expander`, but does not include the collapse button. It is suitable for display when there is no *ExpanderEx.Content*.

- **ExpanderExWrapper**: Contains a `MainContent` and a `WrapContent`. As can be seen from the screenshot below, it can adjust its layout according to the change of container width. When the width is not enough to display both in same line, it will move the `WrapContent` to the next line.

- **ExpanderExDescriptor**: It is a fixed combination of *icon*, *title* and *description text*, usually used in the `ExpanderEx.Header` display.

- **ExpanderExMenuPanel**: When `ExpanderEx.Content` needs to display multiple lines of configuration items, you can use this control as a content container. When using this container, the child control should be `ExpanderExWrapper` to set the UI performance of the child control uniformly.

- **ExpanderExItemSeparater**: Used in `ExpanderExMenuPanel` as a dividing line between items.

![It7hRE.png](https://s3.jpg.cm/2021/09/03/It7hRE.png)

## Usage

Simply create an ExpanderEx with content:

```xml
<uwp:ExpanderEx x:Name="SimpleExpanderEx">
    <uwp:ExpanderEx.Header>
        <uwp:ExpanderExWrapper Style="{StaticResource WrapperInExpanderHeaderStyle}">
            <uwp:ExpanderExWrapper.MainContent>
                <uwp:ExpanderExDescriptor Title="Complete ExpanderEx" Description="Show some settings!">
                  <!-- Icon -->
                </uwp:ExpanderExDescriptor>
            </uwp:ExpanderExWrapper.MainContent>
            <uwp:ExpanderExWrapper.WrapContent>
                <!-- Some content -->
            </uwp:ExpanderExWrapper.WrapContent>
        </uwp:ExpanderExWrapper>
    </uwp:ExpanderEx.Header>
    <uwp:ExpanderEx.Content>
        <uwp:ExpanderExMenuPanel>
            <uwp:ExpanderExWrapper>
                <!-- Content -->
            </uwp:ExpanderExWrapper>
            <uwp:ExpanderExItemSeparator StrokeThickness="1" />
            <uwp:ExpanderExWrapper>
                <!-- Content -->
            </uwp:ExpanderExWrapper>
        </uwp:ExpanderExMenuPanel>
    </uwp:ExpanderEx.Content>
</uwp:ExpanderEx>
```

Before using `ExpanderExWrapper` in `ExpanderEx.Header`, you need to create a **Style**, which is suitable for the scene when `ExpanderEx.Content` is not empty, to adjust the margins to achieve the ideal display effect:

```xml
<!-- Wrapper style at the head of Expander (ExpanderEx with content) -->
<Style x:Key="WrapperInExpanderHeaderStyle" TargetType="expander:ExpanderExWrapper">
    <Setter Property="InlineWidePadding" Value="0,8,0,12" />
    <Setter Property="InlineIntermediatePadding" Value="0,8,0,12" />
    <Setter Property="WrapRowSpacing" Value="0" />
    <Setter Property="WrapMargin" Value="0,8,0,12" />
</Style>
```

The project provides a large number of state switching margins for `ExpanderExWrapper`, and provides some default values. 

There are currently three states:

- **Wide**: 
    `MainContent` and `WrapContent` can be displayed in parallel, and the space is relatively abundant, we can add a proper amount of margin on both sides.

- **Intermediate**: 
    `MainContent` and `WrapContent` can be displayed in parallel, but the space is small, the margin should be reduced at this time.

- **Wrap**: 
    The remaining space is not enough for `MainContent` and `WrapContent` to be displayed in parallel, at this time `WrapContent` switches to the next line.

## Screenshots

**Wide**

[![01.png](https://www.picbed.cn/images/2021/06/30/01.png)](https://www.picbed.cn/image/LRCzq)

**Medium**

[![02.png](https://www.picbed.cn/images/2021/06/30/02.png)](https://www.picbed.cn/image/LRnyx)

**Narrow**

[![03.png](https://www.picbed.cn/images/2021/06/30/03.png)](https://www.picbed.cn/image/LRE9U)
